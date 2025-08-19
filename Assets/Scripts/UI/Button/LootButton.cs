using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LootButton : Button
{
    private float _clickThreshold = 0.25f;
    private float _pointerDownTime;
    private bool _isHolding;
    [SerializeField] private Image _iconLoot;
    [SerializeField] private ScrollLoot _SL;

    private Weapon _weapon;

    public void SetIconLoot(Sprite sprite)
    {
        _iconLoot.sprite = sprite;
    }

    public void SetWeapon(Weapon weapon)
    {
        _weapon = weapon;
    }

    public void OnLootButtonClick()
    {
        Debug.Log("CLicked");
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
