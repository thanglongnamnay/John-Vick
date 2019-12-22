using System.Collections;
using Melees;
using UnityEngine;

namespace Units.Enemies.Bosses {
    public class Perkin : Creep {
        protected override void Start() {
            base.Start();
            maxHp = 200;
            hp = 200;
            moveSpeed = 1.25f;
            StartCoroutine(setKnife());
        }

        private IEnumerator setKnife() {
            yield return new WaitForSeconds(.1f);
            setWeapon<Knife>();
        }
    }
}