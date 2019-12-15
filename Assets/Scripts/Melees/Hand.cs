using System;

namespace Melees {
    public class Hand : Melee {
        public override float damage {
            get { return 5; }
        }

        public override float fireRate {
            get { return .5f; }
        }

        public override int durable {
            get { return int.MaxValue; }
        }
    }
}