using Controller;

namespace Units.Enemies.Bosses {
    public class Iosef : Creep {
        protected override void Awake() {
            base.Awake();
            maxHp = 150;
            hp = 150;
            moveSpeed = 1.5f;
        }

        protected override void Update() {
            base.Update();
            foreach (var skill in skills) {
                skill.use();
            }
        }
        
        protected override void onDead(float after = 0) {
            base.onDead(after);
            GameController.victory();
        }
    }
}