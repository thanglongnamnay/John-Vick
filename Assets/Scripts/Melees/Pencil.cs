using Controller;
using UnityEngine;

namespace Melees {
    public class Pencil : Melee {
        public override Sprite renderedSprite {
            get { return GameController.instance.meleeSprites[2]; }
        }
        private float _damage = 50;
        public override float damage {
            get {
                _damage -= 15;
                return _damage;
            }
        }

        public override float fireRate {
            get { return 2; }
        }

        public override int durable {
            get { return 3; }
            set { throw new System.NotImplementedException(); }
        }
    }
}