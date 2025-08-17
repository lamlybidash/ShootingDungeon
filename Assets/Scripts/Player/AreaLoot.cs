using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaLoot : MonoBehaviour
{
    private List<Weapon> _nearItems = new List<Weapon>();
    private List<GameObject> _lootButtons = new List<GameObject>();
    [SerializeField] private GameObject _lootButtonPfb;
    [SerializeField] private GameObject listButtonParent;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ItemDrop")
        {
            Debug.Log(collision.name);
            AddButtonLoot(collision.GetComponent<Weapon>());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "ItemDrop")
        {
            RemoveButtonLoot(collision.GetComponent<Weapon>());
        }
    }

    private void AddButtonLoot(Weapon weapon)
    {
        GameObject btx;
        btx = null;
        btx = FindButton();
        if (btx == null)
        {
            btx = Instantiate(_lootButtonPfb);
            _lootButtons.Add(btx);
            btx.transform.SetParent(listButtonParent.transform, false);
        }
        //btx;
        _nearItems.Add(weapon);
    }

    private void RemoveButtonLoot(Weapon weapon)
    {
        _nearItems.Remove(weapon);
    }

    private GameObject FindButton()
    {
        foreach (var bt in _lootButtons)
        {
            if (!bt.activeInHierarchy)
            {
                return bt;
            }
        }
        return null;
    }

}