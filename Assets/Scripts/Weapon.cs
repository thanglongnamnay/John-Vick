using System;
using Units;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public abstract class Weapon : MonoBehaviour {
	public Unit owner;
	public abstract Sprite renderedSprite { get; }
	public abstract float damage {get;}
	public abstract float fireRate {get;}

	public virtual void attack() {
		if (canAttack()) playAttackAnimation();
	}
	protected abstract void playAttackAnimation();
	protected abstract bool canAttack();

	protected virtual void OnEnable() {
		GetComponent<SpriteRenderer>().sprite = renderedSprite;
	}

	protected virtual void Update () {
		if (Input.GetMouseButtonDown(0)) {
			attack();
		}
	}
}