using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaLoot : MonoBehaviour
{
    private List<ItemDrop> _nearItems = new List<ItemDrop>();
    [SerializeField] private List<LootButton> _lootButtons = new List<LootButton>();
    [SerializeField] private GameObject _lootButtonPfb;
    [SerializeField] private GameObject ContentScrollView;
    [SerializeField] private ScrollLoot SCLoot;
    private int countItemNear = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ItemDrop")
        {
            AddButtonLoot(collision.GetComponent<ItemDrop>());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "ItemDrop")
        {
            RemoveButtonLoot(collision.GetComponent<ItemDrop>());
        }
    }

    private void AddButtonLoot(ItemDrop item)
    {
        if(item.isDroped == false)
        {
            return;
        }
        countItemNear++;
        LootButton lb;
        lb = null;
        lb = FindButton();
        if (lb == null)
        {
            GameObject btx;
            btx = Instantiate(_lootButtonPfb, ContentScrollView.transform);
            btx.transform.SetParent(ContentScrollView.transform, false);
            lb = btx.GetComponent<LootButton>();
            _lootButtons.Add(lb);
        }
        lb.SetItemDrop(item);
        lb.gameObject.SetActive(true);
        _nearItems.Add(item);
        UpdateKhung();
    }

    private void RemoveButtonLoot(ItemDrop item)
    {
        _nearItems.Remove(item);
        countItemNear--;
        foreach (LootButton lb in _lootButtons)
        {
            if (lb._item == item)
            {
                lb.gameObject.SetActive(false);
                break;
            }
        }
        UpdateKhung();
    }

    private void UpdateKhung()
    {
        SCLoot.SetActiveKhung(countItemNear > 0);
    }    

    private LootButton FindButton()
    {
        foreach (var bt in _lootButtons)
        {
            if (!bt.gameObject.activeInHierarchy)
            {
                return bt;
            }
        }
        return null;
    }
}