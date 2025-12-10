using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine1 : MonoBehaviour
{
    public BoardController mazeControllerScript;  

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Freeze ball
            Rigidbody rb = other.attachedRigidbody;
            if (rb != null)
            {
                rb.linearVelocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                rb.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
            }

            // Freeze maze movement
            if (mazeControllerScript != null)
                mazeControllerScript.enabled = false;

        
        }
    }
}