using UnityEngine;

public class GamePause : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private Animator pauseAnimation;
    public static bool cursorSpawned = false;

    private void Update()
    {
        // Check if the Escape key is pressed and the game is not over.
        if (Input.GetKeyDown(KeyCode.Escape) && !UniversalPlayerData.isGameOver)
        {
            // Toggle pause state.
            if (UniversalPlayerData.isGamePaused)
            {
                Resume(); // Resume the game if paused.
            }
            else
            {
                Pause(); // Pause the game if not paused.
            }
        }
    }

    // Pause the game.
    public void Pause()
    {
        UniversalPlayerData.isGamePaused = true; // Change the pause state.
        pauseMenu.SetActive(true); // Activate the pause menu panel.
        pauseAnimation.speed = 1; // Change the animation speed.
        Time.timeScale = 0; // Freeze the game to pause.
    }

    // Resume the game.
    public void Resume()
    {
        UniversalPlayerData.isGamePaused = false; // Change the pause state.
        pauseMenu.SetActive(false); // Deactivate the pause menu panel.
        pauseAnimation.speed = 0; // Change the animation speed.
        Time.timeScale = 1; // Unfreeze the game to resume.
    }
}
