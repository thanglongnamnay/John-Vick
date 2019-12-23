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
		public float damage;
		public float timeToLive = 5;
		public bool isPenetrable;

		private RaycastHit2D[] _hits;

		private void Awake() {
			gameObject.SetActive(false);
		}

		private void OnEnable() {
			destroy(timeToLive);
			StartCoroutine(handleEnable());
		}

		IEnumerator handleEnable() {
			yield return new WaitForSeconds(0);
			var transform1 = transform;
			if (isPenetrable) {
				_hits = Physics2D.RaycastAll(transform1.position,
					transform1.right);
				Debug.Log("len = " + _hits.Length);
				if (_hits.Length == 0) yield break;
				foreach (var hit in _hits) {
					var unitCollider = hit.collider.GetComponent<UnitCollider>();
					Debug.Log("hit: " + hit.collider.name);

					var hitChance = Random.value;
					if (unitCollider && unitCollider.unit.evasion <= hitChance) {
						StartCoroutine(hurt(unitCollider, hit));
					}
				}
			}
			else {
				var hit = Physics2D.Raycast(transform1.position, transform1.right);
				if (!hit) yield break;
				_hits = new[] {hit};
				StartCoroutine(handleHit(hit));
				var unitCollider = hit.collider.GetComponent<UnitCollider>();

				var hitChance = Random.value;
				//Debug.Log("hit: " + hit.collider.name);
				if (unitCollider && unitCollider.unit.evasion <= hitChance) {
					StartCoroutine(hurt(unitCollider, hit));
				}
			}
		}

		// Update is called once per frame
		private void Update () {
			var delta = speed * Time.deltaTime * transform.right;
			if (_hits != null && !isPenetrable && _hits.Length > 0) {
				var distanceToHit = (Vector3) _hits[0].point - transform.position;
				if (delta.magnitude > distanceToHit.magnitude) {
					delta = distanceToHit;
				}
			}
			transform.position += delta;
		}

		private IEnumerator hurt(UnitCollider unitCollider, RaycastHit2D hit) {
			var timeTravel = hit.distance / speed;
			yield return new WaitForSeconds(timeTravel);
			if (unitCollider) {
				unitCollider.unit.damage(damage * unitCollider.dmgMul / (timeTravel * 2 + 1));
			}
		}
		
		private IEnumerator handleHit(RaycastHit2D hit) {
			var unitCollider = hit.collider.GetComponent<UnitCollider>();
			if (unitCollider != null && unitCollider.unit.evasion >= Random.value) yield break;
			destroy(hit.distance / speed + .1f);
			yield return new WaitForSeconds(hit.distance / speed);
			transform.position = hit.point;
		}

		public void destroy(float after = 0) {
			StartCoroutine(_destroy(after));
		}

		private IEnumerator _destroy(float after) {
			yield return new WaitForSeconds(after);
			gameObject.SetActive(false);
			isPenetrable = false;
		}

//		private void OnTriggerEnter2D(Collider2D other) {
//			if (other.GetComponent<UnitCollider>() == null) return;
//			var unit = other.gameObject.GetComponent<UnitCollider>().unit;
//			if (!other.CompareTag("UnitCollider") ||
//			    unit == owner ||
//			    Random.value <= unit.evasion) return;
//			
//			unit.damage(damage);
//			if (!isPenetrable) destroy(
//		}
	}
}
