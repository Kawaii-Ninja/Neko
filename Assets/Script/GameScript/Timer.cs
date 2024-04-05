using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class Timer : MonoBehaviour
{
    UniversalPlayerData upd;
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] Image timerBar;
    [SerializeField] float initialTime = 60f;

    public float time;

    private void Start()
    {
        // Find the UniversalPlayerData object in the scene and initialize its current score.
        upd = FindFirstObjectByType<UniversalPlayerData>();
        time = initialTime;
        StartCoroutine(StartCountdown());
    }

    private void Update()
    {
        // Ensure that time remains within valid bounds
        time = Mathf.Clamp(time, 0f, initialTime);

        // Display the time in seconds
        timerText.text = time.ToString("F1") + "s";

        // Update the timer bar
        UpdateTimerBar();
    }
    
    private void UpdateTimerBar()
    {
        if (timerBar != null)
        {
            float lerpSpeed = 3f * Time.deltaTime;
            float targetFillAmount = Mathf.Clamp(time / initialTime, 0f, 1f);
            timerBar.fillAmount = Mathf.Lerp(timerBar.fillAmount, targetFillAmount, lerpSpeed);
        }
    }

    IEnumerator StartCountdown()
    {
        while (time > 0)
        {
            yield return new WaitForSeconds(0.1f);
            time -= 0.1f;
        }

        // When the countdown reaches zero
        // Update game state
        UpdateGameState();
    }

    private void UpdateGameState()
    {
        upd.canPlay = false;
        upd.isPlaying = false;
        UniversalPlayerData.isGameOver = true;
        upd.isPlayerOut = true;
    }
}
