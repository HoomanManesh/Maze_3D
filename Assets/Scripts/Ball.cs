using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

public class BallControl : MonoBehaviour
{
    private Rigidbody rb; // Reference to the Rigidbody component

    public Transform respawnPoint; // Assign in Inspector

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Get the Rigidbody component

    }

        
    

    private void OnTriggerEnter(Collider other)  // Detect trigger collisions
    {
        Debug.Log("Triggered with: " + other.gameObject.tag);
        if (other.gameObject.CompareTag("FinishPoint")) // Check for FinishPoint tag
        {
            rb.isKinematic = true; // Stop ball movement
            transform.position = respawnPoint.position; // Move ball to respawn point
            rb.isKinematic = false; 
    }

}
}