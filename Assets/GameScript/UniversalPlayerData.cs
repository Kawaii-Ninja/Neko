using UnityEngine;

public class UniversalPlayerData : MonoBehaviour
{
    // Player statistics
    [Header("Player statistics")]
    public int missedStreaks;
    public int combo;
    public int highScore;
    public int currentScore;

    // Game state flags
    [Header("Game state flages")]
    public bool isPlaying = false;
    public bool canPlay = false;
    public bool isPlayerOut = false;

    [Header("Global Variables")]
    public static bool isGameOver = false;
    public static bool isGamePaused = false;
}
