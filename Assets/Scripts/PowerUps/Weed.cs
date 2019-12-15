using Units;

namespace PowerUps {
    public class Weed : PowerUp {
        protected override void affect(Player player) {
            player.increaseMoveSpeed(player.moveSpeed * 1.3f, 30);
        }
    }
}