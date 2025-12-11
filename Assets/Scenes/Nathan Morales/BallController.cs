using UnityEngine;

public class BallController : MonoBehaviour
{

    public float speed = 1.0f;
    private Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 force = new Vector3(moveX, 0, moveZ);

        rb.AddForce(force * speed);
    }

    private void OnTriggerEnter(Collider other){
        Debug.Log("Trigger Enter:" + other.gameObject.tag);
    }
}
