using UnityEngine;

public class PointerTrigger : MonoBehaviour
{
    CheckerLogic checkerLogic;
    GameObject _curentChecker;
    UniversalPlayerData upd;
    ScoreManager scoreManager;
    ComboStreak comboStreak;
    bool onCircle;

    private void Awake()
    {
        // Find and assign references to components.
        upd = FindObjectOfType<UniversalPlayerData>();
        scoreManager = FindObjectOfType<ScoreManager>();
        comboStreak = FindObjectOfType<ComboStreak>();
    }

    void Update()
    {
        // Destroy the checker object.
        DestroyCircleObject(checkerLogic);
    }

    // Triggers when an object is entered.
    void OnTriggerEnter2D(Collider2D collider)
    {
        // Check if the object's tag is correct.
        if (collider.CompareTag("Checkers"))
        {
            onCircle = true; // Set the state if the object is on the circle.
            checkerLogic = collider.gameObject.GetComponent<CheckerLogic>(); // Get the CheckerLogic component.
            _curentChecker = collider.gameObject;
        }
    }

    // Triggers when an object is exited.
    void OnTriggerExit2D(Collider2D collider)
    {
        // Check if the object's tag is correct.
        if (collider.CompareTag("Checkers"))
        {
            onCircle = false; // Set the state if the object is out of the circle.
            checkerLogic = null; // Clear the CheckerLogic component.
        }
    }

    // Destroy the checker object.
    void DestroyCircleObject(CheckerLogic checkerLogic)
    {
        // Check if the game is not paused and the cursor is on the circle.
        if (onCircle && !UniversalPlayerData.isGamePaused && !UniversalPlayerData.isGameOver)
        {
            // Check if the 'T' key or the left mouse button is clicked.
            if (Input.GetKeyDown(KeyCode.T) && checkerLogic.onLine || Input.GetMouseButtonDown(0) && checkerLogic.onLine)
            {
                // Get the score points and destroy the checker object.
                Destroy(checkerLogic.gameObject, .3f);
                scoreManager.GetScore(checkerLogic.checkers.point);
                _curentChecker.GetComponent<CheckerLogic>().velocity = 0;
                _curentChecker.GetComponent<Animator>().SetTrigger("die");
                ResetPlayerMissedStreak(); // Reset the player's missed streak.
                AddCombo(); // Increment the combo streak.
                comboStreak.IncreaseCombo(); // Increase the combo.
            }
        }
    }

    // Reset the player's missed streak.
    void ResetPlayerMissedStreak()
    {
        // Reset the missed streak if it's greater than 0.
        if (upd.missedStreaks > 0)
            upd.missedStreaks = 0;
    }

    // Increment the combo streak.
    void AddCombo()
    {
        upd.combo++;
    }
}
