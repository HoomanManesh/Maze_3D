using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Ball / Maze setup")]
    public Rigidbody ballPrefab;        // drag Ball prefab
    public string[] mazeSceneNames;     // e.g. "Maze_1", "Maze_2", ...

    private Rigidbody currentBall;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SpawnBallAt(Vector3 position, Quaternion rotation)
    {
        if (currentBall != null)
            Destroy(currentBall.gameObject);

        currentBall = Instantiate(ballPrefab, position, rotation);
    }

    public void LoadRandomMaze()
    {
        if (mazeSceneNames == null || mazeSceneNames.Length == 0)
        {
            Debug.LogError("LevelManager: No maze scenes assigned!");
            return;
        }

        int index = Random.Range(0, mazeSceneNames.Length);
        string sceneName = mazeSceneNames[index];
        SceneManager.LoadScene(sceneName);
    }

    public void LoadFirstMaze(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
