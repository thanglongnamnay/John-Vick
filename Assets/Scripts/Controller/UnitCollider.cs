using Units;
using UnityEngine;

namespace Controller {
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class UnitCollider : MonoBehaviour {
        public Unit unit;
    }
}