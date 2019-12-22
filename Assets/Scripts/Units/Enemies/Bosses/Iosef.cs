namespace Units.Enemies.Bosses {
    public class Iosef : Creep {
        protected override void Start() {
            base.Start();
            maxHp = 150;
            hp = 150;
            moveSpeed = 1;
        }
    }
}