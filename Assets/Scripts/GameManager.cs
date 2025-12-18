using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Ball / Maze setup")]
    public Rigidbody ballPrefab;        // drag Ball prefab
    public string[] mazeSceneNames;     // e.g. "Maze_1", "Maze_2", ...

    private Rigidbody currentBall; // reference to the current ball instance

    private void Awake() // Singleton pattern
    {
        if (Instance != null && Instance != this) // Ensure only one instance exists
        {
            Destroy(gameObject);
            return;
        }

        Instance = this; // Set the instance
        DontDestroyOnLoad(gameObject); // Persist across scenes
    }


// Spawn the ball at a given position and rotation
    public void SpawnBallAt(Vector3 position, Quaternion rotation)
    {
        if (currentBall != null)
            Destroy(currentBall.gameObject); // Remove existing ball

        currentBall = Instantiate(ballPrefab, position, rotation); // Create new ball
    }


// Load a random maze scene from the list
    public void LoadRandomMaze()
    {
        if (mazeSceneNames == null || mazeSceneNames.Length == 0)
        {
            Debug.LogError("LevelManager: No maze scenes assigned!");
            return;
        }

        int index = Random.Range(0, mazeSceneNames.Length); // Pick a random index
        string sceneName = mazeSceneNames[index];
        SceneManager.LoadScene(sceneName); // Load the selected scene
    }


// Load the first maze scene in the list
    public void LoadFirstMaze(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
