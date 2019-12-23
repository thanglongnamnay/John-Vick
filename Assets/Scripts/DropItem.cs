using System;
using Guns;
using Melees;
using Units;
using UnityEngine;

[RequireComponent(typeof(Weapon))]
public class DropItem : MonoBehaviour {
    public Weapon weapon { get; set; }

    private SpriteRenderer _renderer;

    public void changeWeapon(Unit unit) {
        switch (weapon.GetType().Name) {
            case "Deagle":
                unit.setWeapon<Deagle>();
                break;
            case "AssaultRifle":
                unit.setWeapon<AssaultRifle>();
                break;
            case "Shoty":
                unit.setWeapon<Shoty>();
                break;
            case "Sniper":
                unit.setWeapon<Sniper>();
                break;
            case "Hand":
                unit.setWeapon<Hand>();
                break;
            case "Knife":
                unit.setWeapon<Knife>();
                break;
            case "Pencil":
                unit.setWeapon<Pencil>();
                break;
            default:
                throw new ArgumentOutOfRangeException("unit", weapon.GetType().Name, null);
        }
    }

    private void Start() {
        _renderer = GetComponent<SpriteRenderer>();
        _renderer.sprite = weapon.renderedSprite;
    }
}