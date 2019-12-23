namespace Skills {
	public class Kevlar : PassiveSkill {
		protected override void affect() {
			unit.armor = .6f;
		}
	}
}	
