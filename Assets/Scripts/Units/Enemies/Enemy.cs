using Controller;
using Guns;
using Melees;
using Random = UnityEngine.Random;

namespace Units.Enemies {
    public abstract class Enemy : Unit {
        public override UnitType type {
            get { return UnitType.Enemy; }
        }

        protected Player player;

        public override float evasion { get; set; }
        protected override void Start() {
            base.Start();
            player = GameController.instance.player;
        }
    }
}