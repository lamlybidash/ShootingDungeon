using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    private GameObject _UILoot;
    public IItem item;
    public IPickupable pickup;
    public bool isDroped = false;
    private void Awake()
    {
        _UILoot = null;
        
    }

    public void SetupItemDrop(IItem item, IPickupable pickup)
    {
        this.item = item;
        this.pickup = pickup;
    }

    public void Pickup()
    {
        pickup.Pickup();
    }    

}
