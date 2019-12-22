using Controller;
using Guns;
using Melees;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Units.Enemies {
    public abstract class Enemy : Unit {

        private bool _isDropItem;
        public override UnitType type {
            get { return UnitType.Enemy; }
        }

        protected Player player;

        public override float evasion { get; set; }

        protected override void Start() {
            base.Start();
            player = GameController.instance.player;
        }

        protected override void onDead(float after = 0) {
            GetComponentInChildren<Animator>().Play("Hurt");
            base.onDead(after + 1);
            if (!(weapon is Hand) && !_isDropItem) {
                _isDropItem = true;
                var drop = Instantiate(GameController.instance.gunDrop, transform.position, Quaternion.identity);
                drop.GetComponent<DropItem>().weapon = weapon;
            }
        }
    }
}