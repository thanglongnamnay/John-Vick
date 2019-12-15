using System.Linq;
using Units;

namespace PowerUps {
    public class Mag : PowerUp {
        public override void affect(Player player) {
            var playerGunList = player.gunList;
            playerGunList[playerGunList.Length].increaseMag();
        }
    }
}