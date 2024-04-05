using UnityEngine;
using TMPro;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    UniversalPlayerData upd;
    [SerializeField] TextMeshProUGUI scoreText;
    public int score = 0;
    private bool isScoreUpdating = false;
    private Coroutine scoreUpdateCoroutine;

    private void Start()
    {
        // Find the UniversalPlayerData object in the scene and initialize its current score.
        upd = FindFirstObjectByType<UniversalPlayerData>();
        upd.currentScore = 0;
        upd.highScore = GetHighScore();
    }

    void Update()
    {
        // Check if the game is not over and update the score.
        if (score > upd.currentScore && !UniversalPlayerData.isGameOver && !isScoreUpdating)
        {
            // Start the coroutine to update the score smoothly.
            scoreUpdateCoroutine = StartCoroutine(ScoreUpdate());
            isScoreUpdating = true;
        }

        // Check if the game is over and update the score.
        if (UniversalPlayerData.isGameOver && isScoreUpdating)
        {
            // Stop the coroutine to prevent further score updates.
            StopCoroutine(scoreUpdateCoroutine);
            isScoreUpdating = false;
            // Check if the current score is higher than the high score and update it if necessary.
            CheckAndUpdateHighScore();
        }
        // Update the score text on the UI.
        UpdateScoreText();
    }

    // Coroutine to smoothly update the score.
    IEnumerator ScoreUpdate()
    {
        while (upd.currentScore < score)
        {
            // Increment the current score gradually for a smoother transition.
            upd.currentScore++;
            yield return new WaitForSeconds(0.000003f); // Wait for a short time before the next increment.
        }
        isScoreUpdating = false;
    }

    // Update the score text on the UI.
    void UpdateScoreText()
    {
        scoreText.text = upd.currentScore.ToString();
    }

    // Add to the current score.
    public void GetScore(int n_score)
    {
        score += n_score;
    }

    // Check if the current score is higher than the high score and update it if necessary.
    public void CheckAndUpdateHighScore()
    {
        if (GetHighScore() < upd.currentScore)
        {
            UpdateHighScore(upd.currentScore);
        }
    }

    // Save the high score to PlayerPrefs.
    void UpdateHighScore(int score)
    {
        PlayerPrefs.SetInt("HighScore", score);
        PlayerPrefs.Save();
    }

    // Retrieve the high score from PlayerPrefs.
    int GetHighScore()
    {
        // Retrieve and return the high score.
        int highScore = PlayerPrefs.GetInt("HighScore");
        return highScore;
    }
}
