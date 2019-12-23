using Controller;
using UnityEngine;

namespace Melees {
    public class Hand : Melee {
        public override Sprite renderedSprite {
            get { return GameController.instance.meleeSprites[0]; }
        }
        public override float damage {
            get { return 5; }
        }

        public override float fireRate {
            get { return .5f; }
        }

        public override string weaponName {
            get { return "Hand"; }
        }

        public override WeaponName wName {
            get { return WeaponName.Hand; }
        }

        public override int durable {
            get { return int.MaxValue; }
            set {}
        }
    }
}