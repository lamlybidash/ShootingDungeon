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
    [SerializeField] private Image iconLoot;

    public void SetIconLoot(Sprite sprite)
    {
        iconLoot.sprite = sprite;
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
        if(heldTime <= _clickThreshold && !_isHolding)
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
