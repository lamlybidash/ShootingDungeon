using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class WeaponSlot : MonoBehaviour
{
    public Weapon weapon;
    public Image icon;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI bulletText;
    public Reload reloadUI;
    public GameObject selectedFrame;
    public Button button;
    public Sprite _iconNull;

    private WeaponController wc;

    private void Start()
    {
        wc = GameObject.FindGameObjectWithTag("WeaponController").GetComponent<WeaponController>();
        //spagety
        if (weapon != null)
        {
            Equip(weapon);
        }
        else
        {
            SetupNull();
        }
    }

    public void Equip(Weapon weapon)
    {
        this.weapon = weapon;
        if (weapon != null)
        {
            icon.sprite = weapon.Icon;
            nameText.text = weapon.Name;
            Setup();
        }
    }

    public void SetSelected(bool selected)
    {
        selectedFrame.SetActive(selected);
    }

    private void Setup()
    {
        weapon.ClearAllEvent();
        weapon.eReload += ReloadUI;
        weapon.eShoot += UIShoot;
    }

    private void ReloadUI(float time)
    {
        reloadUI.ReloadUI(time);
    }

    private void UIShoot(float time, int current, int total)
    {
        reloadUI.UIShoot(time);
        UpdateTextBullet(current, total);
    }

    private void UpdateTextBullet(int current, int total)
    {
        bulletText.text = $"{current}/{total}";
        if (total == -1)
        {
            bulletText.text = "∞";
        }
    }

    private void SetupNull()
    {
        weapon = null;
        if (weapon == null)
        {
            icon.sprite = _iconNull;
            nameText.text = "NONE";
        }
    }

    public void SelectOnClick(Action action)
    {
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(() =>
        {
            action?.Invoke();
        });
    }
}