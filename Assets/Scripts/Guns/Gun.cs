using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Guns {
	public abstract class Gun : Weapon {
		private const int StabGain = 30;
		public Transform bulletPrefab;

		private int _mag = 0;
		private float _lastShootTime = 0;
		private int _magNum = 1;
		private float _currentRecoil = 0;

		public float currentRecoil {
			get { return _currentRecoil; }
			private set { _currentRecoil = value; }
		}

		protected int magNum {
			get { return _magNum; }
			set { _magNum = value; }
		}

		public abstract int magSize { get; }
		public abstract float reloadTime { get; }
		public abstract float recoil { get; }
		public abstract float inaccuracy { get; }

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
				_currentRecoil += recoil;
				_mag -= 1;
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

		protected void reload() {
			// todo: play anim
			if (_magNum <= 0) {
				//todo play some sound
				return;
			}

			_magNum -= 1;
			_lastReloadTime = Time.time;
			_mag = magSize;
			playReloadAnimation();
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

			if (Time.time - _lastShootTime >= fireRate) {
				var stabGain = StabGain * Time.deltaTime;
				if (_currentRecoil > stabGain) _currentRecoil -= stabGain;
				else _currentRecoil = 0;
			}
		}
	}
}