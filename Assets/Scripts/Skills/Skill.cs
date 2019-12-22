using System;
using Units;
using UnityEngine;

namespace Skills {
	public abstract class Skill : MonoBehaviour {
		public Unit unit;
		public abstract SkillType type { get; }
		public abstract void use();
		protected abstract void affect();

		private void OnEnable() {
			if (!unit) unit = GetComponent<Unit>();
		}
	}
}	
