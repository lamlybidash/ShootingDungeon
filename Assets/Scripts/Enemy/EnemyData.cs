using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GameData/Create Enemy Data", fileName = "EnemyData")]

public class EnemyData : ScriptableObject
{
    public string nameE;
    public float damage;
    public float timePerShot;
    public float rangeAttack;
    public GameObject unitPfb;
    public string acName;
}