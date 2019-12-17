using System;
using System.Collections;
using Controller;
using Guns;
using Melees;
using UnityEngine;
using UnityEngine.Assertions;

namespace Units {
	[RequireComponent(typeof(Movable))]
	public abstract class Unit : MonoBehaviour {
		public WeaponController weaponController { get; protected set; }
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
		protected Movable _movable;
		public Weapon weapon {
			get { return weaponController.weapon; }
		}

		public void setWeapon<T>() where T : Weapon {
			weaponController.setWeapon<T>();
		}

		public void damage(float v) {
			hp -= v;
//			Debug.Log(gameObject.name + " hp: " + hp);
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
			weaponController = GetComponentInChildren<WeaponController>();
			Assert.IsNotNull(_movable);
			Assert.IsNotNull(weaponController);
			weaponController.unit = this;
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
