using System;
using System.Collections;
using Controller;
using Guns;
using Melees;
using UnityEngine;

namespace Units {
	[RequireComponent(typeof(Movable))]
	public abstract class Unit : MonoBehaviour {
		public WeaponController weaponController;
		public float hp { get; protected set; }
		public abstract UnitType type { get; }
		public float moveSpeed {
			get { return _movable.speed; }
			protected set {
				_movable.speed = value;
			}
		}

		public abstract float evasion { get; protected set; }

		private float _tempMoveSpeed;
		private Movable _movable;
		public Weapon weapon {
			get { return weaponController.weapon; }
		}

		public void setWeapon<T>() where T : Weapon {
			weaponController.setWeapon<T>();
		}

		public void damage(float v) {
			hp -= v;
			if (hp <= 0) {
				//todo: play dead animation
				Destroy(gameObject);
			}
		}

		public void heal(float v) {
			hp += v;
		}

		protected virtual void Start() {
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
