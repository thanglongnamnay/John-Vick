using System;
using Controller;
using Units;
using UnityEngine;
using UnityEngine.Assertions;

[RequireComponent(typeof(SpriteRenderer))]
public abstract class Weapon : MonoBehaviour {
	public Unit owner;
	public abstract Sprite renderedSprite { get; }
	public abstract float damage { get; }
	public abstract float fireRate { get; }
	public abstract WeaponType type { get; }

	public virtual void attack() {
		if (canAttack()) playAttackAnimation();
	}
	protected abstract void playAttackAnimation();
	public abstract bool canAttack();

	protected virtual void OnEnable() {
		if (GameController.instance != null) {
			GetComponent<SpriteRenderer>().sprite = renderedSprite;
		}
	}

	public virtual void onUpdate () {
		if (Input.GetMouseButtonDown(0)) {
			attack();
		}
	}

	private void Start() {
		if (owner == null) owner = GetComponentInParent<Unit>();
	}
}