namespace Units.Enemies.Bosses {
    public class Perkin : Creep {
        private float _minDistance;
        protected override void Start() {
            base.Start();
            hp = 200;
            moveSpeed = 1.25f;
        }
    }
}