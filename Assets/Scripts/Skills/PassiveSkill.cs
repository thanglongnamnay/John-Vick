using System;
using UnityEngine;

public class ActiveSkill {
	public bool used { get; private set; }
	public override SkillType type { get { return SkillType.Passive ; } }

	public override void use() {
		if (!used) {
			used = true;
			affect();
		}
	}
}	
