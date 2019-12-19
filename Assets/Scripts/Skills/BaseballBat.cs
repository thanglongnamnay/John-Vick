using System;
using UnityEngine;

public class BaseballBat : ActiveSkill {
	public override float cooldown { get { return 5; } }
	protected override void affect() {
		(unit.weapon as Melee).meleeCollider.enable();
	}
}	
