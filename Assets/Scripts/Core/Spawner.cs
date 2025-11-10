using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField] private GameObject enemy;

    public void GenerateEnemy()
    {
        enemy.SetActive(true);
        enemy.GetComponent<Health>().Revive();
    }
}
