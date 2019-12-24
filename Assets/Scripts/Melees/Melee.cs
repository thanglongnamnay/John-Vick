using System;
using System.Collections;
using Controller;
using UnityEngine;
using UnityEngine.Assertions;

namespace Melees {
    public abstract class Melee : Weapon {
        public MeleeCollider meleeCollider;
        
        private float _lastAttackTime = -10;
        private AudioSource _audio;
        private GameObject _slash;

        public override WeaponType type {
            get { return WeaponType.Melee; }
        }
        public override void attack() {
            base.attack();
            if (canAttack()) {
                _lastAttackTime = Time.time;
                StartCoroutine(enableMeleeCollider());
            }
        }

        private IEnumerator enableMeleeCollider() {
            yield return new WaitForSeconds(.2f);
            _audio.Play();
            _slash.SetActive(true);
            yield return new WaitForSeconds(.3f);
            _slash.SetActive(false);
            meleeCollider.enable = true;
        }

        protected override void playAttackAnimation() {
            //todo: play anim
        }

        public override bool canAttack() {
            return owner.hp > 0 
                   && Time.time - _lastAttackTime >= fireRate;
        }

        private void Start() {
            _audio = GetComponent<AudioSource>();
            Assert.IsNotNull(_audio);
            _audio.clip = AudioController.instance.swing;
            _slash = transform.Find("slash").gameObject;
            _slash.SetActive(false);
        }

        private void OnDestroy() {
            _slash.SetActive(false);
        }

        public override void onUpdate() {
            base.onUpdate();
            if (Input.GetMouseButton(0)) {
                if (canAttack()) {
                    attack();
                }
            }
        }
    }
}