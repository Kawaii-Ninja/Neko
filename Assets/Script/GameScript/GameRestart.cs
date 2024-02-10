using UnityEngine;
using UnityEngine.SceneManagement;

public class GameRestart : MonoBehaviour
{
    // Restart the game.
    public void GameReset()
    {
        // Reset game states and time scale.
        ResetGameStates();
        // Load the previous scene.
        LoadPreviousScene();
    }

    // Reset game states and time scale.
    private void ResetGameStates()
    {
        // Reset game paused and game over states.
        UniversalPlayerData.isGamePaused = false;
        UniversalPlayerData.isGameOver = false;
        // Unfreeze the time.
        Time.timeScale = 1;
    }

    // Load the previous scene.
    private void LoadPreviousScene()
    {
        // Load the scene that was active before.
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }
}
