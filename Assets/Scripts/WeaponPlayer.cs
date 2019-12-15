using System;
using Controller;
using UnityEngine;
using UnityEngine.Assertions;

public class WeaponPlayer : MonoBehaviour {
    private WeaponController _weaponController;

    private void Start() {
        _weaponController = GetComponentInChildren<WeaponController>();
        Assert.IsNotNull(_weaponController);
    }

    private void Update() {
        _weaponController.weapon.onUpdate();
    }
}