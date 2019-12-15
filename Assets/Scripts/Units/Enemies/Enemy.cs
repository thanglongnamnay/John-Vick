namespace Units.Enemies {
    public class Enemy : Unit {
        public override UnitType type {
            get { return UnitType.Enemy; }
        }

        public override float evasion { get; protected set; }

    }
}