using Unity.VisualScripting;
using UnityEngine;

public class CheckerLogic : MonoBehaviour
{
    Rigidbody2D rb;
    public Checkers checkers;
    [SerializeField] float stoppingTime = 1f;
    public float velocity = 0;

    [Header("Animation")]
    Animator animator;
    public bool onLine = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>(); // Initialize the animator variable
        velocity = checkers.velocity;
    }

    private void Update()
    {
        if (UniversalPlayerData.isGameOver)
            StopTheCheckers();
        else
            Movement();
    }

    // Moves the object downwards at the velocity specified in the Checkers object.
    void Movement()
    {
        // Adjusts the object's vertical velocity, multiplied by Time.deltaTime for frame rate independence.
        rb.velocity = new Vector2(0, -velocity * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Line")) onLine = true;
    }
    // Destroys the game object when it exits a trigger collider tagged as "ENDZONE".
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Line")) onLine = false;
        if (collision.CompareTag("ENDZONE"))
        {
            DestroyObject();
        }
    }


    // Destroys the game object after a delay.
    private void DestroyObject()
    {
        // Check if the game object is on the line.
        if (onLine)
            // Destroys the game object with a 1-second delay.
            Destroy(gameObject, 1f);
    }

    // To smoothly stop the checker if the game is over.
    void StopTheCheckers()
    {
        // Calculate the target velocity (zero)
        Vector2 targetVelocity = Vector2.zero;

        // Gradually decrease the velocity over time using damping
        rb.velocity -= rb.velocity * Time.deltaTime / stoppingTime;

        // Ensure velocity is exactly zero
        if (Vector2.Dot(rb.velocity, targetVelocity) <= 0f)
        {
            StopTheAnimationSmoothly();
            rb.velocity = Vector2.zero;
        }
    }

    // To smoothly stop the checker animation if the game is over.
    void StopTheAnimationSmoothly()
    {
        // Gradually decrease the animation speed over time using damping.
        animator.speed -= animator.speed * Time.deltaTime / stoppingTime;
        // Ensure animation speed is exactly zero.
        if (animator.speed <= 0)
        {
            animator.speed = 0;
        }
    }
}
