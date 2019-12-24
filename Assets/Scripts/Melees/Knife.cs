using Controller;
using UnityEngine;

namespace Melees {
    public class Knife : Melee {
        public float damageMul = 1;

        public override Sprite renderedSprite {
            get { return GameController.instance.meleeSprites[1]; }
        }
        public override float damage {
            get { return 18 * damageMul; }
        }

        public override float fireRate {
            get { return 1; }
        }

        public override string weaponName {
            get { return "Knife"; }
        }

        public override WeaponName wName {
            get { return WeaponName.Knife; }
        }
    }
}