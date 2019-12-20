using System.Collections;
using UnityEngine;

namespace Skills {
    public class Dodge : ActiveSkill {
        private const float Duration = .75f;
        private float _oldEvasion;
        protected override void affect() {
            _oldEvasion = unit.evasion;
            unit.evasion = 1;
            StartCoroutine(resetEvasion());
        }

        private IEnumerator resetEvasion() {
            yield return new WaitForSeconds(Duration);
            unit.evasion = _oldEvasion;
        }

        public override float cooldown {
            get { return 3; }
        }
    }
}