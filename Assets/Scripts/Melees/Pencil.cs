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
                if (_damage > 15) {
                    _damage -= 15;
                }

                return _damage;
            }
        }

        public override float fireRate {
            get { return 2; }
        }

        public override string weaponName {
            get { return "Pencil"; }
        }

        public override WeaponName wName {
            get { return WeaponName.Pencil; }
        }
    }
}