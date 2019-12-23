using Guns;

namespace Skills {
	public class InfinitePistol : PassiveSkill {
		protected override void affect() {
			var gun = unit.weapon as Gun;
			if (gun != null) gun.increaseMag(int.MaxValue - 10);
		}
	}
}	
