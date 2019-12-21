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

		private void Start() {
			destroy(timeToLive);
			var transform1 = transform;
			if (isPenetrable) {
				_hits = Physics2D.RaycastAll(transform1.position,
					transform1.right,
					GameController.instance.screenSize.magnitude);
				if (_hits.Length == 0) return;
				Debug.Log("len = " + _hits.Length);
				foreach (var hit in _hits) {
					var unitCollider = hit.collider.GetComponent<UnitCollider>();
					Debug.Log("hit: " + hit.collider.name);

					var hitChance = Random.value;
					if (unitCollider && unitCollider.unit.evasion <= hitChance) {
						StartCoroutine(hurt(unitCollider, hit));
					}
				}
			} else {
				var hit = Physics2D.Raycast(transform1.position, transform1.right, GameController.instance.screenSize.magnitude);
				if (!hit) return;
				_hits = new []{hit};
				StartCoroutine(handleHit(hit));
				var unitCollider = hit.collider.GetComponent<UnitCollider>();
				Debug.Log("uniCollider: " + (unitCollider != null));

				var hitChance = Random.value;
				Debug.Log("hit: " + hit.collider.name);
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
			Debug.Log("hurt: " + hit.collider.name);
			yield return new WaitForSeconds(hit.distance / speed);
			if (unitCollider) {
				unitCollider.unit.damage(damage * unitCollider.dmgMul);
			}
		}
		
		private IEnumerator handleHit(RaycastHit2D hit) {
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
