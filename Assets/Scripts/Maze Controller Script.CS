using UnityEngine;

// Simple board controller for tilting a maze/board using player input.
// The script reads the Unity input axes and applies rotation to the GameObject
// while clamping the tilt to a safe maximum so the board doesn't flip over.
public class BoardController : MonoBehaviour
{
    // How fast the board tilts in degrees per second in response to input
    public float rotationSpeed = 50f;

    // Maximum allowed tilt (in degrees) on the X and Z axes (prevents flipping)
    public float maxRotation = 10f;

    // Toggle to control the board using a Camera's rotation instead of keys/mouse deltas
    public bool useCameraControl = true;

    // Camera that controls the board tilt. If left null, Camera.main will be used at runtime.
    public Camera controlCamera;

    // Multiplier applied to the camera's Euler angles to control how strongly
    // the camera rotation affects the board tilt.
    public float cameraTiltMultiplier = 1f;

    // Smoothing speed when following the camera rotation. Higher values = snappier.
    public float smoothSpeed = 8f;

    // Update is called once per frame
    void Update()
    {
        if (useCameraControl)
        {
            // Ensure we have a camera reference
            if (controlCamera == null) controlCamera = Camera.main;

            if (controlCamera != null)
            {
                // Read camera local Euler angles and convert into signed range
                Vector3 camEuler = controlCamera.transform.localEulerAngles;
                if (camEuler.x > 180f) camEuler.x -= 360f;
                if (camEuler.z > 180f) camEuler.z -= 360f;

                // Target tilt is camera's pitch/roll scaled by multiplier and clamped
                float targetX = Mathf.Clamp(camEuler.x * cameraTiltMultiplier, -maxRotation, maxRotation);
                float targetZ = Mathf.Clamp(camEuler.z * cameraTiltMultiplier, -maxRotation, maxRotation);

                // Smoothly follow the camera's tilt from the current board rotation
                Vector3 currentRotation = transform.localEulerAngles;
                if (currentRotation.x > 180f) currentRotation.x -= 360f;
                if (currentRotation.z > 180f) currentRotation.z -= 360f;

                float newRotationX = Mathf.Lerp(currentRotation.x, targetX, Time.deltaTime * smoothSpeed);
                float newRotationZ = Mathf.Lerp(currentRotation.z, targetZ, Time.deltaTime * smoothSpeed);

                transform.localEulerAngles = new Vector3(newRotationX, 0f, newRotationZ);
            }
        }
        else
        {
            // Keyboard fallback: read input axes. By default in Unity: "Vertical" is W/S or up/down arrow,
            // "Horizontal" is A/D or left/right arrow. Multiplying by Time.deltaTime
            // makes rotation frame-rate independent.
            float rotationX = Input.GetAxis("Vertical") * rotationSpeed * Time.deltaTime;

            // We negate horizontal input so that pushing right rotates the board to tilt
            // the ball to the right (coordinate/visual mapping). Adjust if your input
            // mapping or model orientation differs.
            float rotationZ = -Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;

            // Get current local Euler angles. Unity returns values in [0,360), so we
            // convert angles greater than 180 to a signed range (-180,180) to simplify
            // clamping logic below.
            Vector3 currentRotation = transform.localEulerAngles;
            if (currentRotation.x > 180f) currentRotation.x -= 360f; // convert to negative range
            if (currentRotation.z > 180f) currentRotation.z -= 360f; // convert to negative range

            // Compute the new rotation values and clamp them to [-maxRotation, maxRotation]
            // so the board cannot tilt beyond the configured safety angle.
            float newRotationX = Mathf.Clamp(currentRotation.x + rotationX, -maxRotation, maxRotation);
            float newRotationZ = Mathf.Clamp(currentRotation.z + rotationZ, -maxRotation, maxRotation);

            // Apply the clamped rotation back to the transform. We keep the Y rotation at 0
            // because this controller only tilts the board on X and Z axes.
            transform.localEulerAngles = new Vector3(newRotationX, 0f, newRotationZ);
        }
    }
}
