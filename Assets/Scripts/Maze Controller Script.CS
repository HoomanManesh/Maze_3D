using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MazeControllerScript : MonoBehaviour
{
    public float rotationSpeed = 50f; // Speed of board rotation
    public float maxRotation = 10f; // Maximum tilt angle

// Update is called once per frame
// Handle board rotation based on user input
    void Update()
    {   // Get input for rotation
        float rotationX = Input.GetAxis("Vertical") * rotationSpeed * Time.deltaTime;
        float rotationZ = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;

        Vector3 currentRotation = transform.localEulerAngles;

        // Convert the range to [-180, 180]
        if (currentRotation.x > 180f) currentRotation.x -= 360f;
        if (currentRotation.z > 180f) currentRotation.z -= 360f;

    // Clamp the rotation to the maxRotation limits
        float newRotationX = Mathf.Clamp(currentRotation.x + rotationX, -maxRotation, maxRotation);
        float newRotationZ = Mathf.Clamp(currentRotation.z + rotationZ, -maxRotation, maxRotation);
    // Apply the new rotation
        transform.localEulerAngles = new Vector3(newRotationX, currentRotation.y, newRotationZ);
    }
}
