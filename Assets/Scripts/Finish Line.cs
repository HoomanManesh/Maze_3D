using UnityEngine;

public class FinishLine : MonoBehaviour
{
   [Header("Name of the scene to load")]
    public string nextSceneName;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the thing that entered the trigger is the ball (tagged Player)
        if (other.CompareTag("Player"))
        {
            // (Optional) stop the ball movement before changing scenes
            Rigidbody rb = other.attachedRigidbody;
            if (rb != null)
            {
                rb.linearVelocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }

            // Load the next scene
        }
    }
}
