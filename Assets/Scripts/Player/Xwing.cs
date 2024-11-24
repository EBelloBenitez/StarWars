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
    
    private void Awake()
    {
        
    }
    
    private void Update()
    { 
        Movement();
        Turning();
    }

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
}
