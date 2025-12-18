using UnityEngine;
using TMPro;


// UI class to manage the timer display
public class UI : MonoBehaviour
{
    public TextMeshProUGUI timerText;

    private float elapsedTime = 0f; // Time in seconds
    private bool isRunning = false; // Is the timer active
    private bool hasStarted = false; // Has the timer started at least once



    void Start()
    {
        elapsedTime = 0f;
        isRunning = false;
        hasStarted = false;
        UpdateTimerUI();
    }


// Update is called once per frame
// Start the timer on first key press and update time while running


    void Update()
    {
        // Start the timer when a key is pressed
        if (!hasStarted && Input.anyKeyDown)
        {
            isRunning = true;
            hasStarted = true;
        }

        // Update timer if running
        if (isRunning)
        {
            elapsedTime += Time.deltaTime;
            UpdateTimerUI();
        }
    }


// Update the timer UI text
// Format: MM:SS.ms
    void UpdateTimerUI()
    {
        int minutes = Mathf.FloorToInt(elapsedTime / 60f);
        int seconds = Mathf.FloorToInt(elapsedTime % 60f);
        int milliseconds = Mathf.FloorToInt((elapsedTime * 1000f) % 1000f / 10f);

        timerText.text = $"{minutes:00}:{seconds:00}.{milliseconds:00}";
    }

    // Just stop the timer
    public void StopTimer()
    {
        isRunning = false;
    }


// Get the elapsed time in seconds
    public float GetElapsedTime()
    {
        return elapsedTime;
    }
}
