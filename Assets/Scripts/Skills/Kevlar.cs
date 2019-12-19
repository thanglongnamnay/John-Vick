using System;
using UnityEngine;

public class Kevlar : PassiveSkill {
	protected override void affect() {
		unit.weapon.ammor = .6f;
	}
}	
