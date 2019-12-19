using Melees;

namespace Skills {
	public class KnifeArtist : PassiveSkill {
		protected override void affect() {
			var knife = unit.weapon as Knife;
			if (knife != null) knife.damageMul = 1.5f;
		}
	}
}	
