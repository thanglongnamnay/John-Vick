using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Guns {
	public abstract class Gun : Weapon {
		private const int StabGain = 45;
		public Transform bulletPrefab;

		private float _lastShootTime = -10;
		private float _lastReloadTime = -10;
		private int _magNum = 1;

		public float currentRecoil { get; set; }

		protected int magNum {
			get { return _magNum; }
			set { _magNum = value; }
		}

		public override WeaponType type {
			get { return WeaponType.Gun; }
		}

		public abstract int magSize { get; }
		public abstract float reloadTime { get; }
		public abstract float recoil { get; }
		public abstract float inaccuracy { get; }

		public int mag { get; private set; }

		public float lastShootTime {
			private get { return _lastShootTime; }
			set { _lastShootTime = value; }
		}
		public float lastReloadTime {
			private get { return _lastReloadTime; }
			set { _lastReloadTime = value; }
		}
		public bool isReloading {
			get { return Time.time - _lastReloadTime >= reloadTime; }
		}

		public Gun() {
			mag = 0;
			currentRecoil = 0;
		}

		public override void attack() {
			base.attack();
			if (canAttack()) {
				makeBullet();
				currentRecoil += recoil;
				mag -= 1;
				_lastShootTime = Time.time;
			}
		}

		public void increaseMag(int v) {
			_magNum += v;
		}

		protected float shootAngle {
			get { return transform.rotation.eulerAngles.z + Random.Range(-inaccuracy, inaccuracy); }
		}

		protected abstract void makeBullet();
		protected abstract void playReloadAnimation();

		public void reload() {
			// todo: play anim
			if (_magNum <= 0) {
				//todo play some sound
				return;
			}

			_magNum -= 1;
			_lastReloadTime = Time.time;
			if (mag == 0) {
				_lastReloadTime += .5f;
				mag = magSize;
			}
			else {
				mag = magSize + 1;
			}

			playReloadAnimation();
		}

		public override bool canAttack() {
			return mag > 0
			       && Time.time - _lastShootTime >= fireRate
			       && Time.time - _lastReloadTime >= reloadTime;
		}

		private void Start() {
			mag = magSize;
		}

		public override void onUpdate () {
			base.onUpdate();
			if (Input.GetKeyDown(KeyCode.R)) {
				reload();
			}

			if (Time.time - _lastShootTime >= fireRate) {
				var stabGain = StabGain * Time.deltaTime;
				if (currentRecoil > stabGain) currentRecoil -= stabGain;
				else currentRecoil = 0;
			}
		}
	}
}