using System;
using Controller;
using Melees;
using UnityEngine;

namespace Units.Enemies {
    public class Iosef : Creep {
        private float _minDistance;
        protected override void Start() {
            base.Start();
            hp = 150;
            moveSpeed = 1;
        }

        private void Update() {
        }
    }
}