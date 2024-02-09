using UnityEngine;

public class CollideManager : MonoBehaviour
{
    public event System.Action<Collider2D> EnteredTrigger;
    public event System.Action<Collider2D> ExitedTrigger;

    // Triggers when any object enters the collider and sends a message to the subscribers.
    private void OnTriggerEnter2D(Collider2D collider)
    {
        EnteredTrigger?.Invoke(collider);
    }

    // Triggers when any object exits the collider and sends a message to the subscribers.
    private void OnTriggerExit2D(Collider2D collider)
    {
        ExitedTrigger?.Invoke(collider);
    }
}
