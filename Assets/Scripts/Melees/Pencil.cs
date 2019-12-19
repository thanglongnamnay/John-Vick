using Controller;
using UnityEngine;

namespace Melees {
    public class Pencil : Melee {
        public override Sprite renderedSprite {
            get { return GameController.instance.meleeSprites[1]; }
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

        private int _durable = 3;
        public override int durable {
            get { return _durable; }
            set { _durable = value; }
        }
    }
}