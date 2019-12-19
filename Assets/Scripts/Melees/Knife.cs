using Controller;
using UnityEngine;

namespace Melees {
    public class Knife : Melee {
        public float damageMul { get; set; }

        public override Sprite renderedSprite {
            get { return GameController.instance.meleeSprites[1]; }
        }
        public override float damage {
            get { return 18 * damageMul; }
        }

        public override float fireRate {
            get { return 1; }
        }

        private int _durable = 40;
        public override int durable {
            get { return _durable; }
            set { _durable = value; }
        }
    }
}