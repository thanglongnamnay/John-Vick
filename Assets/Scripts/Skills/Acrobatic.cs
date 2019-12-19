using System;
using UnityEngine;

public class Acrobatic : PassiveSkill {
	protected override void affect() {
		unit.evasion += .3f;
	}
}	
