using UnityEngine;

public class BallSpawnPoint : MonoBehaviour
{
    private void Start()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.SpawnBallAt(transform.position, transform.rotation);
        }
    }
}
