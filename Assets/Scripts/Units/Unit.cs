using System.Collections.Generic;
using Guns;
using UnityEngine;

namespace Units {
	public abstract class Unit : MonoBehaviour {
		public abstract float hp { get; protected set; }
		public abstract float moveSpeed { get; set; }

		public Weapon[] weaponList {
			get { return GetComponentsInChildren<Weapon>(); }
		}

		public Gun[] gunList {
			get { return GetComponentsInChildren<Gun>();  }
		}

		public void damage(float v) {
			hp -= v;
		}

		public void heal(float v) {
			hp += v;
		}

	}
}
