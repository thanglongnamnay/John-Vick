using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Controller;
using Guns;
using Melees;
using Skills;
using UnityEngine;
using UnityEngine.Assertions;

namespace Units {
	[RequireComponent(typeof(Movable))]
	public abstract class Unit : MonoBehaviour {
		public WeaponController weaponController { get; protected set; }
        public List<Skill> skills = new List<Skill>();
        [SerializeField] private float _hp = 100;

        public float hp {
	        get { return _hp; }
	        protected set { _hp = value; }
        }

        public float armor { get; set; }
		public abstract UnitType type { get; }
		public float moveSpeed {
			get { return movable.speed; }
			protected set {
				movable.speed = value;
			}
		}

		public abstract float evasion { get; set; }

		private float _tempMoveSpeed;
		protected Movable movable;

		public Weapon weapon {
			get { return weaponController.weapon; }
		}

		public void setWeapon<T>() where T : Weapon {
			weaponController.setWeapon<T>();
		}

		public void randomWeapon(WeaponType weaponType) {
			if (weaponType == WeaponType.Gun) {
				var index = Random.Range(0, 4);
				switch (index) {
					case 1:
						setWeapon<Shoty>();
						break;
					case 2:
						setWeapon<AssaultRifle>();
						break;
					case 3:
						setWeapon<Sniper>();
						break;
					default:
						setWeapon<Deagle>();
						break;
				}
			}
			else {
				var index = Random.Range(0, 4);
				switch (index) {
					case 1:
						setWeapon<Knife>();
						break;
					default:
						setWeapon<Hand>();
						break;
				}
			}
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
			movable = GetComponent<Movable>();
			weaponController = GetComponentInChildren<WeaponController>();
			Assert.IsNotNull(movable);
			Assert.IsNotNull(weaponController);
			weaponController.unit = this;
			foreach (var skill in skills) {
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
			skills.First(s => s is T).use();
		}
	}
}
