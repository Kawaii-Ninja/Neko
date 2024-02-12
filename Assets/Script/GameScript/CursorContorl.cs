using UnityEngine;

public class CursorControl : MonoBehaviour
{
    UniversalPlayerData upd;

    private void Start()
    {
        // Find and assign reference to UniversalPlayerData component.
        upd = Object.FindFirstObjectByType<UniversalPlayerData>();

        // Hide the cursor at the start of the game.
        Cursor.visible = false;
    }

    private void Update()
    {
        // Control cursor visibility based on game state.
        CursorVisibleControl();

        // If the game is playable and not paused, allow the cursor to move.
        if (upd.canPlay && !UniversalPlayerData.isGamePaused)
        {
            MoveCursorToMousePosition();
        }
    }

    // Control cursor visibility based on game state.
    private void CursorVisibleControl()
    {
        // Show cursor if the game is over or paused.
        Cursor.visible = UniversalPlayerData.isGameOver || UniversalPlayerData.isGamePaused;
    }

    // Move the GameObject to the mouse position.
    private void MoveCursorToMousePosition()
    {
        // Get the mouse position in screen coordinates.
        Vector3 mousePosition = Input.mousePosition;

        // Convert screen coordinates to world coordinates.
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // Set the object's position to the mouse position.
        transform.position = new Vector3(worldMousePosition.x, worldMousePosition.y, transform.position.z);
    }
}
