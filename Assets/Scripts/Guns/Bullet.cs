using System;
using System.Collections;
using Controller;
using Units;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Guns {
	[RequireComponent(typeof(Collider2D))]
	public class Bullet : MonoBehaviour {
		public Unit owner;
		public float speed = 5; // pixel/sec
		public float damage = 0;
		public float timeToLive = 5;
		public bool isPenetrable = false;

		private bool _hit = false;

		private void Start() {
			Destroy(gameObject, timeToLive);
		}

		// Update is called once per frame
		private void FixedUpdate () {
			transform.position += speed * Time.deltaTime * transform.right;
			
			if (_hit) return;
			var hit = Physics2D.Raycast(transform.position, transform.right);
			
			if (!hit) return;
//			Debug.Log("Hit: " + hit.transform.gameObject.name);
			var hitDistance = hit.distance / speed;
			Destroy(gameObject, hitDistance + .1f);
			_hit = true;
			var unitCollider = hit.transform.GetComponent<UnitCollider>();
			
			if (!unitCollider) return;
			StartCoroutine(hurt(unitCollider, hit));
		}

		private IEnumerator hurt(UnitCollider unitCollider, RaycastHit2D hit) {
			yield return new WaitForSeconds(hit.distance / speed);
//			Debug.Log("unitCollider: " + hit.transform.gameObject.name);
			transform.position = hit.point;
			if (unitCollider) {
//				Debug.Log("Damage: " + damage * unitCollider.dmgMul);
				unitCollider.unit.damage(damage * unitCollider.dmgMul);
			}
		}

//		private void OnTriggerEnter2D(Collider2D other) {
//			if (other.GetComponent<UnitCollider>() == null) return;
//			var unit = other.gameObject.GetComponent<UnitCollider>().unit;
//			if (!other.CompareTag("UnitCollider") ||
//			    unit == owner ||
//			    Random.value <= unit.evasion) return;
//			
//			unit.damage(damage);
//			if (!isPenetrable) Destroy(gameObject);
//		}
	}
}
