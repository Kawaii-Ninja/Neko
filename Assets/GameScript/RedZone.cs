using UnityEngine;

public class RedZone : MonoBehaviour
{
    GameObject ball;
    [SerializeField] CollideManager redZoneTrigger;
    UniversalPlayerData upd;
    Timer timerCom;

    private void Awake()
    {
        // Subscribe to the events when the script is enabled.
        redZoneTrigger.EnteredTrigger += OnRedZoneTriggerEnter;
        redZoneTrigger.ExitedTrigger += OnRedZoneTriggerExit;
    }

    private void OnDisable()
    {
        // Unsubscribe from the events when the script is disabled.
        redZoneTrigger.EnteredTrigger -= OnRedZoneTriggerEnter;
        redZoneTrigger.ExitedTrigger -= OnRedZoneTriggerExit;
    }

    // Triggered when an object enters the red zone.
    private void OnRedZoneTriggerEnter(Collider2D collider)
    {
        // Check if the object's tag is correct.
        if (collider.CompareTag("Checkers"))
        {
            // Assign the game object to the 'ball' variable.
            ball = collider.gameObject;
            // Assign components to references.
            upd = FindObjectOfType<UniversalPlayerData>();
            timerCom = FindObjectOfType<Timer>();
        }
    }

    // Triggered when an object exits the red zone.
    private void OnRedZoneTriggerExit(Collider2D collider)
    {
        // Check if the object's tag is correct.
        if (collider.CompareTag("Checkers"))
        {
            // Destroy the game object.
            Destroy(ball);
            // Add missed streaks if the player missed.
            AddMissedStreaks();
            // Reset the combo.
            ResetCombo();
        }
    }

    // Reset the combo.
    private void ResetCombo()
    {
        upd.combo = 0;
    }

    // Add missed streaks.
    private void AddMissedStreaks()
    {
        upd.missedStreaks++;
        timerCom.time -= upd.missedStreaks * 2; // Decrease the time.
    }
}
