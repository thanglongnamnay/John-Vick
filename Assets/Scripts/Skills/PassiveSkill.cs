namespace Skills {
	public abstract class PassiveSkill : Skill {
		public bool used { get; private set; }
		public override SkillType type { get { return SkillType.Passive ; } }

		public override void use() {
			if (!used) {
				used = true;
				affect();
			}
		}
	}
}	
