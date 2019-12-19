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

		private RaycastHit2D _hit;

		private void Start() {
			Destroy(gameObject, timeToLive);
			var hit = Physics2D.Raycast(transform.position, transform.right, GameController.instance.screenSize.magnitude);
			if (!hit) return;
			_hit = hit;
//			Debug.Log("Hit: " + hit.transform.gameObject.name);
			StartCoroutine(handleHit(hit));
			var unitCollider = hit.transform.GetComponent<UnitCollider>();
			
			if (!unitCollider) return;
			StartCoroutine(hurt(unitCollider));
		}

		// Update is called once per frame
		private void Update () {
			var delta = speed * Time.deltaTime * transform.right;
			if (!isPenetrable && _hit) {
				var distanceToHit = (Vector3) _hit.point - transform.position;
				if (delta.magnitude > distanceToHit.magnitude) {
					delta = distanceToHit;
				}
			}
			transform.position += delta;
		}

		private IEnumerator hurt(UnitCollider unitCollider) {
			yield return new WaitForSeconds(_hit.distance / speed);
			if (unitCollider) {
//				Debug.Log("Damage: " + damage * unitCollider.dmgMul);
				unitCollider.unit.damage(damage * unitCollider.dmgMul);
			}
		}
		
		private IEnumerator handleHit(RaycastHit2D hit) {
			if (!isPenetrable) {
				Destroy(gameObject, hit.distance / speed + .1f);
			}
			yield return new WaitForSeconds(hit.distance / speed);
			transform.position = hit.point;
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
