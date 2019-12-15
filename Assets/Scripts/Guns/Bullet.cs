using System;
using System.Collections;
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
			if (!other.CompareTag("Unit") || other.gameObject.GetComponent<Unit>() == owner) return;
			other.gameObject.GetComponent<Unit>().damage(damage);
			if (!isPenetrable) Destroy(gameObject);
		}
	}
}
