using UnityEngine;

namespace Skills {
	public abstract class ActiveSkill : Skill {
		public override SkillType type {
			get { return SkillType.Active; }
		}
		private float _lastUseTime = -10;
		public abstract float cooldown { get; }
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
}	
