using System;
using Guns;
using Melees;
using Units;
using UnityEngine;

public class DropItem : MonoBehaviour {
    public Unit unit;
    public Weapon weapon;

    public void changeWeapon() {
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
                throw new ArgumentOutOfRangeException("weapon", weapon.GetType().Name, null);
        }
    }
}