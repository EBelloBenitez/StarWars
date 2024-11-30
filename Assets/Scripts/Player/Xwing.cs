using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Xwing : MonoBehaviour
{
    // Global inspector variables
    [Header("Movement")]
    [SerializeField]
    private int speed,
                turnSpeed;

    [Header("Attack")]
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Transform[] posRotBullets;

    // Private variables
    private AudioSource shootAudio;
    
    
    // Event methods
    private void Awake()
    {
        shootAudio = GetComponent<AudioSource>();
    }
    
    private void Update()
    { 
        Movement();
        Turning();
        Attack();   
    }

    // Movement methods
    private void Movement()
    {
        // Determine direction of the motion
        float horizontal = Input.GetAxis("Horizontal"); 
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

        // Move the x-wing
        transform.Translate(speed * Time.deltaTime * direction);

    }

    private void Turning()
    {
        // Determine direction of the rotation 
        float xMouse = Input.GetAxis("Mouse X");
        float yMouse = Input.GetAxis("Mouse Y");
        Vector3 direction = new Vector3(-yMouse, xMouse, 0).normalized;

        // Rotate the x-wing
        transform.Rotate(turnSpeed * Time.deltaTime * direction);
    }

    // Attack methods
    private void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Instantiate bullets and give them velocity
            for (int i = 0; i < posRotBullets.Length; i++)
            {
                Instantiate(bulletPrefab, posRotBullets[i].position, posRotBullets[i].rotation);
            }
            // Play the shoot sound
            shootAudio.Play();
        }
    }
}
