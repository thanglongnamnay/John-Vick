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
			
			transform.position += speed * Time.deltaTime * transform.right.normalized;
			var hit = Physics2D.Raycast(transform.position, transform.right);
			var unit = hit.transform.GetComponentInParent<Unit>();
			if (unit != null) {
				
			}
		}

		private void OnTriggerEnter2D(Collider2D other) {
			if (other.GetComponent<UnitCollider>() == null) return;
			var unit = other.gameObject.GetComponent<UnitCollider>().unit;
			if (!other.CompareTag("UnitCollider") ||
			    unit == owner ||
			    Random.value <= unit.evasion) return;
			
			unit.damage(damage);
			if (!isPenetrable) Destroy(gameObject);
		}
	}
}
