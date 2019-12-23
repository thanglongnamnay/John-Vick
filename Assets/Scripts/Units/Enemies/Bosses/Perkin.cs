using System.Collections;
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
    }
}