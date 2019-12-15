using System;
using System.Collections;
using UnityEngine;

namespace Guns {
	public abstract class Gun : Weapon {
		public Transform bulletPrefab;

		private int _mag = 0;
		private float _lastShootTime = 0;
		private int _magNum = 1;

		public abstract int magSize { get; }
		public abstract float reloadTime { get; }

		public float lastShootTime {
			private get { return _lastShootTime; }
			set { _lastShootTime = value; }
		}

		public float lastReloadTime {
			private get { return _lastReloadTime; }
			set { _lastReloadTime = value; }
		}

		private float _lastReloadTime = 0;
		public override void attack() {
			base.attack();
			if (canAttack()) {
				makeBullet();
				_mag -= 1;
				_lastShootTime = Time.time;
			}
		}

		public void increaseMag() {
			_magNum += 1;
		}

		protected abstract void makeBullet();

		protected virtual void reload() {
			// todo: play anim
			if (_magNum <= 0) {
				//todo play some sound
				return;
			}

			_magNum -= 1;
			_lastReloadTime = Time.time;
			_mag = magSize;
		}

		protected override bool canAttack() {
			return _mag > 0
			       && Time.time - _lastShootTime >= fireRate
			       && Time.time - _lastReloadTime >= reloadTime;
		}

		private void Start() {
			_mag = magSize;
		}
		
		protected override void Update () {
			base.Update();
			if (Input.GetKeyDown(KeyCode.R)) {
				reload();
			}
		}
	}
}