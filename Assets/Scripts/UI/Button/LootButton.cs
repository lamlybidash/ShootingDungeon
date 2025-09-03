using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LootButton : Button
{
    public ItemDrop _item;

    private float _clickThreshold = 0.25f;
    private float _pointerDownTime;
    private bool _isHolding;
    private Image _iconLoot;
    private ScrollLoot _SL;

    public void SetItemDrop(ItemDrop itemDrop)
    {
        if(_iconLoot == null)
        {
            gameObject.SetActive(true);
            _iconLoot = transform.Find("Icon").GetComponent<Image>();
        }
        _item = itemDrop;
        _iconLoot.sprite = itemDrop.item.Icon;
    }

    public void OnLootButtonClick()
    {
        _item.Pickup();
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
        _pointerDownTime = Time.unscaledTime;
        _isHolding = false;
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        float heldTime = Time.unscaledTime - _pointerDownTime;
        if(heldTime <= _clickThreshold && !eventData.dragging)
        {
            base.OnPointerClick(eventData);
        }
        base.OnPointerUp(eventData);
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        //Comment để chặn gọi base
        //Gọi thủ công thông qua thằng OnPointerUp
        //base.OnPointerClick(eventData);
    }
}
