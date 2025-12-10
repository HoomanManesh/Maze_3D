using UnityEngine;

public class MenuController : MonoBehaviour
{
   

    public void OnStartButtonClicked() // Called when Start button is clicked
    {
        if (GameManager.Instance != null)
        {
            //completely random from the first click:
             GameManager.Instance.LoadRandomMaze();
        }
        else
        {
            Debug.LogWarning("MenuController: No LevelManager found.");
        }
    }
}
