using Melees;

namespace Skills {
	public class BaseballBat : ActiveSkill {
		public override float cooldown { get { return 5; } }
		protected override void affect() {
			var melee = unit.weapon as Melee;
			if (melee != null) melee.meleeCollider.enable = true;
		}
	}
}	
