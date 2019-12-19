using System;
using Controller;
using Melees;
using UnityEngine;

namespace Units.Enemies {
    public class Virgo : Archer {
        private float _minDistance;
        protected override void Start() {
            base.Start();
            hp = 350;
            moveSpeed = .75;
        }

        private void Update() {
        }
    }
}