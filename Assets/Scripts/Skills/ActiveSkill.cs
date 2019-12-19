using System;
using UnityEngine;

public class ActiveSkill {
	public Unit unit;
	private float _lastUseTime = -10;
	public abstract float cooldown { get; }
	public abstract SkillType type { get { return SkillType.Active ; } }

	public bool canUse {
		get {
			return Time.time - _lastUseTime >= cooldown;
		}
	}

	public override void use() {
		if (canUse) {
			affect();
		}
	}
}	
