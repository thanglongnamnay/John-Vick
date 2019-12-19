namespace Units.Enemies.Bosses {
    public class Iosef : Creep {
        private float _minDistance;
        protected override void Start() {
            base.Start();
            hp = 150;
            moveSpeed = 1;
        }
    }
}