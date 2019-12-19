using UnityEngine;

namespace Controller {
    public class CameraChase : MonoBehaviour {
        public Transform player;

        public float offsetX;         //Private variable to store the offset distance between the player and camera
        // Use this for initialization
        private void Start () {
            if (player == null) player = GameController.instance.player.transform;
        }
    
        // LateUpdate is called after Update each frame
        private void LateUpdate () {
            if (!player) return;
            
            var transform1 = transform;
            var position = transform1.position;
            position.x = player.position.x + offsetX;
            transform1.position = position;
        }
    }
}