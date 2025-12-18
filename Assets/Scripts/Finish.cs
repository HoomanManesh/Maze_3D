using UnityEngine;

public class FinishZone : MonoBehaviour
{
    [SerializeField] private string ballTag = "Ball"; // Tag to identify the ball



    private void OnTriggerEnter(Collider other) // Detect trigger collisions
    {
        if (other.CompareTag(ballTag))
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.LoadRandomMaze(); // Load a new random maze
            }
        }

       
    }
}
