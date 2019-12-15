namespace Melees {
    public class Knife : Melee {
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