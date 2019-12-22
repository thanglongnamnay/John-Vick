namespace Units.Enemies.Bosses {
    public class Iosef : Creep {
        protected override void Awake() {
            base.Awake();
            maxHp = 150;
            hp = 150;
            moveSpeed = 1;
        }
    }
}