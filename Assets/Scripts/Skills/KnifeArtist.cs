using Melees;
using UnityEngine.Assertions;

namespace Skills {
	public class KnifeArtist : PassiveSkill {
		protected override void affect() {
			Assert.IsNotNull(unit);
			var knife = unit.weapon as Knife;
			if (knife != null) knife.damageMul = 1.5f;
		}
	}
}	
