using Controller;
using UnityEngine;

namespace Melees {
    public class Knife : Melee {
        public override Sprite renderedSprite {
            get { return GameController.instance.meleeSprites[1]; }
        }
        public override float damage {
            get { return 18; }
        }

        public override float fireRate {
            get { return 1; }
        }

        public override int durable {
            get { return 40; }
        }
    }
}