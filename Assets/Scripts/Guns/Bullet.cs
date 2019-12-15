using System;
using System.Collections;
using Controller;
using Units;
using UnityEngine;

namespace Guns {
	[RequireComponent(typeof(Collider2D))]
	public class Bullet : MonoBehaviour {
		public Unit owner;
		public float speed = 5; // pixel/sec
		public float damage = 0;
		public float timeToLive = 5;
		public bool isPenetrable = false;

		private IEnumerator Start() {
			yield return new WaitForSeconds(timeToLive);
			Destroy(gameObject);
		}

		// Update is called once per frame
		private void FixedUpdate () {
			transform.position += speed * Time.deltaTime * transform.right.normalized;
		}

		private void OnTriggerEnter2D(Collider2D other) {
			Debug.Log("Bullet triggered ");
			if (other.CompareTag("UnitCollider") && other.gameObject.GetComponent<UnitCollider>().unit != owner) {
				other.gameObject.GetComponent<UnitCollider>().unit.damage(damage);
				if (!isPenetrable) Destroy(gameObject);
			}
		}
	}
}
