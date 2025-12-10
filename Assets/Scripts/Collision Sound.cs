using UnityEngine;

public class CollisionSound : MonoBehaviour
{
   public AudioSource rollingSource;
    public AudioClip collisionClip;
    public Rigidbody rb;

    public float speedThreshold = 0.1f;

    void Start()
    {
        if (rb == null) rb = GetComponent<Rigidbody>();
        if (rollingSource == null) rollingSource = GetComponent<AudioSource>();

        rollingSource.loop = true;
        rollingSource.playOnAwake = false;
    }

    void Update()
    {
        float speed = rb.linearVelocity.magnitude;

        // Rolling sound
        if (speed > speedThreshold)
        {
            if (!rollingSource.isPlaying)
                rollingSource.Play();
        }
        else
        {
            if (rollingSource.isPlaying)
                rollingSource.Stop();
        }

        // (Optional) adjust volume/pitch by speed
        rollingSource.volume = Mathf.Clamp(speed / 10f, 0f, 1f);
        rollingSource.pitch = Mathf.Lerp(0.8f, 1.2f, speed / 10f);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            rollingSource.PlayOneShot(collisionClip);
        }
    }
}
