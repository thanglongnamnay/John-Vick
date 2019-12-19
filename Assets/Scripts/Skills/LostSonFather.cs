namespace Skills {
	public class LostSonFather : ActiveSkill {
		public override float cooldown { get { return 6; } }
		protected override void affect() {
			unit.weapon.burst();
		}
	}
}	
