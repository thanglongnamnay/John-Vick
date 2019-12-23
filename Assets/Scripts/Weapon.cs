using Controller;
using Units;
using UnityEngine;
using UnityEngine.Assertions;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(AudioSource))]
public abstract class Weapon : MonoBehaviour {
	public Unit owner;
	public AudioSource audioSource;
	private Camera _camera;
	public abstract Sprite renderedSprite { get; }
	public abstract float damage { get; }
	public abstract float fireRate { get; }
	public abstract WeaponType type { get; }
	public abstract WeaponName wName { get; }
	public abstract string weaponName { get; }

	public virtual void attack() {
		if (canAttack()) playAttackAnimation();
	}

	public virtual void burst() {
		if (canAttack()) playAttackAnimation();
	}
	protected abstract void playAttackAnimation();
	public abstract bool canAttack();

	protected virtual void Awake() {
		_camera = Camera.main;
		audioSource = GetComponent<AudioSource>();
		Assert.IsNotNull(audioSource);
	}

	protected virtual void OnEnable() {
		if (GameController.instance != null) {
			GetComponent<SpriteRenderer>().sprite = renderedSprite;
		}
		if (owner == null) owner = GetComponentInParent<Unit>();
	}

	private void Update() {
		audioSource.pitch = Time.timeScale;
		var toCam = transform.position - _camera.transform.position;
		audioSource.panStereo = toCam.x / 5;
	}

	public virtual void onUpdate () {
		if (Input.GetMouseButtonDown(0) && canAttack()) {
			attack();
		}
	}
}