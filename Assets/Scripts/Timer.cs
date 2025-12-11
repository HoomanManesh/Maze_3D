using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    public TextMeshProUGUI timerText;

    private float elapsedTime = 0f;
    private bool isRunning = false;
    private bool hasStarted = false;

    void Start()
    {
        elapsedTime = 0f;
        isRunning = false;
        hasStarted = false;
        UpdateTimerUI();
    }

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

    public float GetElapsedTime()
    {
        return elapsedTime;
    }
}
