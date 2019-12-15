using UnityEngine;

public class KeyboardControl : MonoBehaviour {
    public float speed = 1;
    private void Start() {
    }
    private void FixedUpdate ()
    {
        var moveHorizontal = Input.GetAxis("Horizontal");
        var moveVertical = Input.GetAxis("Vertical");
        transform.position += new Vector3(moveHorizontal, moveVertical, 0);
    }
}