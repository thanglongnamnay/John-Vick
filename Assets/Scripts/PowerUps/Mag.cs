using System.Linq;
using Guns;
using Units;

namespace PowerUps {
    public class Mag : PowerUp {
        private static float amount {
            get {
                var r = Random.Range(0, 100);
                if (r < 5) return 3;
                if (r < 20) return 2;
                return 1;
            }
        }
        protected override void affect(Player player) {
            var gun = player.weapon as Gun;
            if (gun != null) gun.increaseMag(amount);
        }
    }
}