using System;
using UnityEngine;

public class LookAtMouse : MonoBehaviour {
    private Camera _camera;

    // Update is called once per frame
    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Update () {
        var angle = Vector2.SignedAngle(Vector2.right, ((Vector2) _camera.ScreenToWorldPoint(Input.mousePosition) - (Vector2) transform.position).normalized);
        angle = Math.Max(angle, -45);
        angle = Math.Min(angle, 45);
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}