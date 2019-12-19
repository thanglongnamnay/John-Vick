using System;
using Controller;
using Melees;
using UnityEngine;

namespace Units.Enemies {
    public class Perkin : Creep {
        private float _minDistance;
        protected override void Start() {
            base.Start();
            hp = 200;
            moveSpeed = 1.25;
        }

        private void Update() {
        }
    }
}