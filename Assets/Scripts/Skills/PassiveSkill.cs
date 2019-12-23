using System.Collections;
using UnityEngine;

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

		protected override void OnEnable() {
			base.OnEnable();
			StartCoroutine(useAsync());
		}

		IEnumerator useAsync() {
			yield return new WaitForSeconds(0.01f);
			use();
		}
	}
}	
