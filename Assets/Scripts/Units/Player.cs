namespace Units {
    public class Player : Unit {
        protected override void Start() {
            base.Start();
            hp = 100;
            moveSpeed = .75f;
        }
    }
}