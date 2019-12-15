using Units;

namespace PowerUps {
    public class Weed : PowerUp {
        public override void affect(Player player) {
            player.moveSpeed *= 1.2f;
        }
    }
}