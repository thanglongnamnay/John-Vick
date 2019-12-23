using Controller;
using Units;
using UnityEngine;

namespace PowerUps {
    public abstract class PowerUp : MonoBehaviour {
        protected abstract void affect(Unit unit);

        private void OnTriggerEnter2D(Collider2D other) {
            var component = other.GetComponent<UnitCollider>();
            if (component == null || component.unit.type != UnitType.Player) return;
            affect(component.unit);
            Debug.Log("+ammo");
            Destroy(gameObject);
        }
    }
}