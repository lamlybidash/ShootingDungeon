using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollLoot : MonoBehaviour
{
    [SerializeField] private List<LootButton> lootButtons;
    [SerializeField] private GameObject Khung;

    private void Awake()
    {
        //Khung.SetActive(false);
    }

    public void ChangeWeapon(Weapon weapon)
    {


    }

    public void SetupContent()
    {

    } 

    public void SetActiveKhung(bool status)
    {
        Khung.SetActive(status);
    } 
}
