using UnityEngine;

namespace Skills {
	public class Acrobatic : PassiveSkill {
		protected override void affect() {
			unit.evasion += .3f;
			Debug.Log("evasion: " + unit.evasion);
		}
	}
}	
