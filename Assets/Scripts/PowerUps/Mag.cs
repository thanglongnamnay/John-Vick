using System.Linq;
using Guns;
using Units;

namespace PowerUps {
    public class Mag : PowerUp {
        protected override void affect(Player player) {
            var gun = player.weapon as Gun;
            if (gun != null) gun.increaseMag(1);
        }
    }
}