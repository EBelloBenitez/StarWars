 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Serialized variables
    [Header("Movement")]
    [SerializeField]
    private int speed;
    [SerializeField]
    private float minDistanceToPlayer;
    
    [Header("Attack")]
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Transform[] posRotBullet;
    [SerializeField]
    private float timeBetweenBullets;

    GameObject player;

    
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        InvokeRepeating("Attack", 1, timeBetweenBullets);
    }

    void Update()
    {
        if (player == null)
        {
            return;
        }

        transform.LookAt(player.transform.position);
        FollowPlayer();
        
    }

    private void FollowPlayer()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        if (distanceToPlayer > minDistanceToPlayer)
        {
            transform.Translate(speed * Time.deltaTime * Vector3.forward);
        }
    }

    private void Attack()
    {
        for (int i = 0; i < posRotBullet.Length; i++)
        {
            Instantiate(bulletPrefab, posRotBullet[i].position, posRotBullet[i].rotation);
        }
    }
}
