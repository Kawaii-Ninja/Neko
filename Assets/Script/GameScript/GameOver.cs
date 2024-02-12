using UnityEngine;

public class GameOver : MonoBehaviour
{
    UniversalPlayerData upd;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject gameContinuePanel;
    [SerializeField] private Animator pauseAnimation;

    private void Start()
    {
        // Find and assign reference to UniversalPlayerData component.
        upd = Object.FindFirstObjectByType<UniversalPlayerData>();
    }

    private void Update()
    {
        // Check if the game is over and the player is out.
        if (UniversalPlayerData.isGameOver && upd.isPlayerOut)
        {
            // Update game state.
            upd.isPlaying = false;
            // Set up the game over panel.
            SetGameOver();
        }
    }

    // Activate the game over panel and deactivate the game continue panel.
    private void SetGameOver()
    {
        gameOverPanel.SetActive(true);
        gameContinuePanel.SetActive(false);
        // Set animation speed when the game is over.
        SetAnimation();
    }

    // Set animation speed when the game is over.
    private void SetAnimation()
    {
        pauseAnimation.speed = 1;
    }
}
