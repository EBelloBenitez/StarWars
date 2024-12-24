using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] 
    private GameObject enemyPrefab;
    [SerializeField] 
    private Transform[] posRotEnemy;
    [SerializeField] 
    private float timeBetweenEnemies;

    private void Start()
    {
        InvokeRepeating("CreateEnemies", 1, timeBetweenEnemies);
    }

    private void CreateEnemies()
    {
        int n = Random.Range(0, posRotEnemy.Length);
        Instantiate(enemyPrefab, posRotEnemy[n].position, posRotEnemy[n].rotation);
    }
}
    