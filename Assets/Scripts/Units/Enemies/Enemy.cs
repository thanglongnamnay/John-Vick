using System;
using Controller;
using Guns;
using Melees;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Units.Enemies {
    public abstract class Enemy : Unit {
        public override UnitType type {
            get { return UnitType.Enemy; }
        }

        protected Player player;

        public override float evasion { get; protected set; }

        protected void randomWeapon(WeaponType weaponType) {
            if (weaponType == WeaponType.Gun) {
                var index = Random.Range(0, 4);
                switch (index) {
                    case 1:
                        setWeapon<Shoty>();
                        break;
                    case 2:
                        setWeapon<AssaultRifle>();
                        break;
                    case 3:
                        setWeapon<Sniper>();
                        break;
                    default:
                        setWeapon<Deagle>();
                        break;
                }
            }
            else {
                var index = Random.Range(0, 4);
                switch (index) {
                    case 1:
                        setWeapon<Knife>();
                        break;
                    default:
                        setWeapon<Hand>();
                        break;
                }
            }
        }
        
        protected override void Start() {
            base.Start();
            player = GameController.instance.player;
        }
    }
}