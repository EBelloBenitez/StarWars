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
    private float minTimeBetweenBurst,
                  maxTimeBetweenBurst,
                  timeBetweenBullets;

    GameObject player;
    AudioSource shootAudio;

    
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        shootAudio = GetComponent<AudioSource>();
        Invoke("InvokeNextBurst", 1);
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

    private void InvokeNextBurst()
    {
        Burst();
        float delay = Random.Range(minTimeBetweenBurst, maxTimeBetweenBurst);
        Invoke("InvokeNextBurst", delay);
    }

    private void Burst()
    {
        float delay = 0;
        int numberOfBulltets = Random.Range(1, 5);
        for (int i = 0; i < numberOfBulltets; i++)
        {
            Invoke("Attack", delay);
            delay += timeBetweenBullets;
        }
    }

    private void Attack()
    {
        shootAudio.Play();
        for (int i = 0; i < posRotBullet.Length; i++)
        {
            Instantiate(bulletPrefab, posRotBullet[i].position, posRotBullet[i].rotation);
        }
        
    }
}
