using System;
using UnityEngine;

public class InfinitePistol : PassiveSkill {
	protected override void affect() {
		unit.weapon.mag = int.MaxValue;
	}
}	
