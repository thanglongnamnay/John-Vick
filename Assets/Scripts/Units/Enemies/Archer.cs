using Controller;
using Guns;
using UnityEngine;

namespace Units.Enemies {
    public class Archer : Enemy {
        protected override void Start() {
            base.Start();
            hp = 20;
            if (weaponController.weapon.type == WeaponType.Melee) {
                weaponController.setWeapon<Deagle>();
            }
        }
        
        private virtual void Update() {
            if (GameController.instance.player == null) return;
            var distanceToPlayer = GameController.instance.player.transform.position - transform.position;
            
        }
    }
}