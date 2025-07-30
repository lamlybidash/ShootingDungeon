using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GameData/Create Weapon Data", fileName = "WeaponData")]
public class WeaponData : ScriptableObject
{
    public string nameW;
    public float damage;
    public float reloadTime;
    public float speedBullet;
    public float rangeBullet;
    public GameObject bulletPfb;
}
