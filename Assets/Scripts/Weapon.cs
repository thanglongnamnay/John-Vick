using Controller;
using Units;
using UnityEngine;
using UnityEngine.Assertions;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(AudioSource))]
public abstract class Weapon : MonoBehaviour {
	public Unit owner;
	public AudioSource audioSource;
	public abstract Sprite renderedSprite { get; }
	public abstract float damage { get; }
	public abstract float fireRate { get; }
	public abstract WeaponType type { get; }

	public virtual void attack() {
		if (canAttack()) playAttackAnimation();
	}

	public virtual void burst() {
		if (canAttack()) playAttackAnimation();
	}
	protected abstract void playAttackAnimation();
	public abstract bool canAttack();

	protected virtual void OnEnable() {
		if (GameController.instance != null) {
			GetComponent<SpriteRenderer>().sprite = renderedSprite;
		}
		if (owner == null) owner = GetComponentInParent<Unit>();
		audioSource = GetComponent<AudioSource>();
		Assert.IsNotNull(audioSource);
	}

	public virtual void onUpdate () {
		if (Input.GetMouseButtonDown(0) && canAttack()) {
			attack();
		}
	}
}