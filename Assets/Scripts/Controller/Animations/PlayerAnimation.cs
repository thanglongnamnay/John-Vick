using UnityEngine;

namespace Controller.Animations {
    public class PlayerAnimation : MonoBehaviour {
        public Animator animator;
        public Movable movable;
//        private static readonly int State = Animator.StringToHash("state");

        private void Start() {
            if (!animator) animator = GetComponentInChildren<Animator>();
            if (!movable) movable = GetComponentInChildren<Movable>();
        }

        private void Update() {
            animator.Play(movable.direction == Vector2.zero ? "Idle" : "Walk");
//            animator.SetInteger(State, movable.direction == Vector2.zero ? 1 : 2);
        }
    }
}