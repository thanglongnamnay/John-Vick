using System;
using System.Collections;
using Controller;
using Guns;
using Melees;
using UnityEngine;

namespace Units {
	[RequireComponent(typeof(Movable))]
	public abstract class Unit : MonoBehaviour {
		public float hp { get; protected set; }

		public float moveSpeed {
			get { return _movable.speed; }
			private set {
				_movable.speed = value;
			}
		}

		public float evasion { get; protected set; }

		private float _tempMoveSpeed;
		private Movable _movable;
		public Weapon[] weaponList {
			get { return GetComponentsInChildren<Weapon>(); }
		}

		public Gun[] gunList {
			get { return GetComponentsInChildren<Gun>();  }
		}

		public Melee melee {
			get { return GetComponentInChildren<Melee>(); }
		}

		public void damage(float v) {
			hp -= v;
		}

		public void heal(float v) {
			hp += v;
		}

		private void Start() {
			_movable = GetComponent<Movable>();
		}

		public void increaseMoveSpeed(float v, float duration) {
			_tempMoveSpeed = moveSpeed;
			moveSpeed = v;
			StartCoroutine(resetMoveSpeed(duration));
		}

		private IEnumerator resetMoveSpeed(float after) {
			yield return new WaitForSeconds(after);
			moveSpeed = _tempMoveSpeed;
		}
	}
}
