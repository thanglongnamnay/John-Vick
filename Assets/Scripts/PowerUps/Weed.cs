using Units;
using UnityEngine;

namespace PowerUps {
    public class Weed : PowerUp {
        private static float amount {
            get {
                var r = Random.Range(0, 100);
                if (r < 5) return 1.3f * 1.3f * 1.3f;
                if (r < 20) return 1.3f * 1.3f;
                return 1.3f;
            }
        }
        protected override void affect(Player player) {
            player.increaseMoveSpeed(player.moveSpeed * amount, 30);
        }
    }
}