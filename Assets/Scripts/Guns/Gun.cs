using System.Collections;
using Controller;
using Helper;
using UnityEngine;

namespace Guns {
	public abstract class Gun : Weapon {
		private const int StabGain = 45;
		public float barrelOffset;

		protected ObjectPool pool;
		
		private float _lastShootTime = -10;
		private float _lastReloadTime = -10;
		private int _magNum = 2;

		public Vector3 barrelPosition {
			get {
				var transform1 = transform;
				return transform1.position + transform1.right * barrelOffset;
			}
		}
		public float currentRecoil { get; set; }

		public int magNum {
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
		public abstract int config { get; }

		public int mag { get; set; }

		public float lastReloadTime {
			get { return _lastReloadTime; }
			set { _lastReloadTime = value; }
		}

		public override Sprite renderedSprite {
			get { return GameController.instance.gunConfig[config].texture; }
		}

		protected Gun() {
			mag = 0;
			magNum = 0;
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

		protected virtual void makeBullet() {
			if (audioSource != null) {
				audioSource.Play();
			}
		}
		protected abstract void playReloadAnimation();

		public void reload() {
			// todo: play anim
			var audioController = AudioController.instance;
			if (_magNum <= 0) {
				audioController.play(audioController.empty, .5f);
				return;
			}

			if (Time.time - _lastReloadTime >= reloadTime && mag <= magSize) {
				_magNum -= 1;
				_lastReloadTime = Time.time;
				audioController.play(audioController.reload, reloadTime);
				if (mag == 0) {
					//todo play cocking
					_lastReloadTime += .5f;
					mag = magSize;
				}
				else {
					mag = magSize + 1;
				}

				playReloadAnimation();
			}
		}

		public override bool canAttack() {
			return owner.hp > 0 
			       && mag > 0
			       && Time.time - _lastShootTime >= fireRate
			       && Time.time - _lastReloadTime >= reloadTime;
		}

		private void Start() {
			audioSource.clip = GameController.instance.gunConfig[config].shootSound;
			pool = ObjectPool.instance;
		}

		public override void onUpdate () {
			base.onUpdate();
			if (Input.GetMouseButtonDown(0)) {
				if (canAttack()) {
					attack();
				} else if (mag == 0) {
					Debug.Log("Play empty sound");
					AudioController.instance.play(AudioController.instance.empty, 1);
				}
			}
			if (Input.GetKeyDown(KeyCode.R)) {
				reload();
			}

			if (Time.time - _lastShootTime >= fireRate) {
				var stabGain = StabGain * Time.deltaTime;
				if (currentRecoil > stabGain) currentRecoil -= stabGain;
				else currentRecoil = 0;
			}
		}

		public override void burst(int times) {
			StartCoroutine(_burst(times));
		}

		private IEnumerator _burst(int times) {
			for (var i = 0; i < times; ++i) {
				yield return new WaitForSeconds(fireRate / 2);
				makeBullet();
			}
		}
	}
}