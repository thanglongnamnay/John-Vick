using Units;
using UnityEngine;

namespace Controller.Animations {
    public class UnitAnimation : MonoBehaviour {
        public Animator animator;
        public Movable movable;
        public Unit unit;
//        private static readonly int State = Animator.StringToHash("state");

        private void Start() {
            if (!animator) animator = GetComponentInChildren<Animator>();
            if (!movable) movable = GetComponentInChildren<Movable>();
            if (!unit) unit = GetComponent<Unit>();
        }

        private void Update() {
            if (unit.hp <= 0) return;

            animator.Play(movable.direction == Vector2.zero ? "Idle" : "Walk");
//            animator.SetInteger(State, movable.direction == Vector2.zero ? 1 : 2);
        }
    }
}