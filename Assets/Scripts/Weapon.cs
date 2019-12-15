using Units;
using UnityEngine;

public abstract class Weapon : MonoBehaviour {
	public Unit owner;
	public abstract float damage {get;}
	public abstract float fireRate {get;}

	public virtual void attack() {
		if (canAttack()) playAnimation();
	}
	protected abstract void playAnimation();
	protected abstract bool canAttack();
	
	protected virtual void Update () {
		if (Input.GetMouseButtonDown(0)) {
			attack();
		}
	}
}