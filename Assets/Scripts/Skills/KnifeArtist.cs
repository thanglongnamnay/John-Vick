using System;
using UnityEngine;

public class KnifeArtist : PassiveSkill {
	protected override void affect() {
		(unit.weapon as Knife).damage *= 1.5f;
	}
}	
