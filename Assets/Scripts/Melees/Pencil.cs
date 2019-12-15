namespace Melees {
    public class Pencil : Melee {
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
        }
    }
}