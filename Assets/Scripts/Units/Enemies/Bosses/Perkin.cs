using System.Collections;
using Controller;
using Melees;
using UnityEngine;

namespace Units.Enemies.Bosses {
    public class Perkin : Creep {
        protected override void Awake() {
            base.Awake();
            maxHp = 200;
            hp = 200;
            moveSpeed = 2;
            StartCoroutine(setKnife());
        }

        private IEnumerator setKnife() {
            yield return new WaitForSeconds(0);
            setWeapon<Knife>();
        }
        
        protected override void onDead(float after = 0) {
            base.onDead(after);
            GameController.victory();
        }
    }
}