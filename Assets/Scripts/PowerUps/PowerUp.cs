using Units;
using UnityEngine;

namespace PowerUps {
    public abstract class PowerUp : MonoBehaviour {
        public abstract void affect(Player player);
    }
}