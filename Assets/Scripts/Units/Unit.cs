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
        private Skill[] skills;
		public float hp { get; protected set; }
		public float ammor { get; set; }
		public abstract UnitType type { get; }
		public float moveSpeed {
			get { return _movable.speed; }
			protected set {
				_movable.speed = value;
			}
		}

		public abstract float evasion { get; set; }

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
				hp = 0;
				onDead();
			}
		}

		public void heal(float v) {
			hp += v;
		}

		protected virtual void onDead() {
			Destroy(gameObject);
		}

		protected virtual void Start() {
			_movable = GetComponent<Movable>();
			weaponController = GetComponentInChildren<WeaponController>();
			Assert.IsNotNull(_movable);
			Assert.IsNotNull(weaponController);
			weaponController.unit = this;
			foreach (var skill of skills) {
				skill.unit = this;
			}
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

		public void useSkill(int index) {
			skills[index].use();
		}
		public void useSkill<T>() where T : Skill {
			skills.find(s => s is T).use();
		}
	}
}
