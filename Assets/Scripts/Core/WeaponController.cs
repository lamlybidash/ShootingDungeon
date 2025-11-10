using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private Weapon _currentWeapon = null;
    [SerializeField] private List<WeaponSlot> _slots;
    [SerializeField] private List<Weapon> _weaponsInMap;
    [SerializeField] private Transform _arm;

    private int _selectedIndex;   //ô select súng 12 súng 3 dao

    [SerializeField] private Joystick _shootJoystick;

    private void Awake()
    {
        InitAllWeapon();
    }

    void Start()
    {
        _selectedIndex = 2;
        SelectSlot(_selectedIndex);
        SetupWeaponSlot();
    }

    void Update()
    {
        if (_shootJoystick.Direction.magnitude > 0.1f)
        {
            if (_currentWeapon != null)
            {
                _currentWeapon.Shoot(_shootJoystick.Direction);
            }
        }
    }

    //Thay đổi vũ khí
    public void SelectSlot(int index)
    {
        Debug.Log($"Select {index}");

        if (index < 0 || index >= _slots.Count || _slots[index].weapon == null) return;

        _currentWeapon?.gameObject.SetActive(false);
        _slots[_selectedIndex].SetSelected(false);

        _selectedIndex = index;
        _currentWeapon = _slots[index].weapon;
        _currentWeapon.gameObject.SetActive(true);
        for (int i = 0; i < _slots.Count; i++)
        {
            _slots[i].SetSelected(i == _selectedIndex);
        }
    }

    //Gọi khi nhặt vũ khí từ map
    public void EquipWeapon(Weapon weapon)
    {
        weapon.transform.SetParent(_arm);
        weapon.transform.localPosition = new Vector3(0, 0, weapon.transform.localPosition.z);
        weapon.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        weapon.transform.localScale = new Vector3(1f, 1f, 1f);
        weapon.transform.Find("Hand").gameObject.SetActive(true);

        foreach (var slot in _slots)
        {
            if (slot.weapon == null)
            {
                slot.Equip(weapon);
                return;
            }
        }
        // Nếu full thì thay vào slot đang chọn
        var currentSlot = _slots[_selectedIndex];
        // TODO: Drop current weapon (currentSlot.Weapon)
        currentSlot.Equip(weapon);

        Debug.Log("trans: ");
        Debug.Log(weapon.transform);
        //SelectSlot(_selectedIndex);
    }

    private void InitAllWeapon()
    {
        foreach (Weapon w in _weaponsInMap)
        {
            w.InitData();
        }
    }
    public void InitWeapon(Weapon weapon)
    {
       weapon.InitData();
        _weaponsInMap.Add(weapon);
    }

    private void SetupWeaponSlot()
    {
        for (int i = 0; i < _slots.Count; i++)
        {
            int index = i;
            _slots[i].SelectOnClick(() => SelectSlot(index));
        }
    }
}