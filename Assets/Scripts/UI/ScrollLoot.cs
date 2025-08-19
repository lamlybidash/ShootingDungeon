using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollLoot : MonoBehaviour
{
    [SerializeField] private WeaponController _wc;
    [SerializeField] private List<LootButton> lootButtons;
    private Weapon _weapon = null;

    public void ChangeWeapon(Weapon weapon)
    {
        _weapon = weapon;

    } 
}
