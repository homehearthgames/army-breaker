using System.Collections;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed = 5f;
    public float cornerVariance = .5f;
    private Rigidbody2D rigidBody;
    private Vector2 currentVelocity;
    private InterfaceController interfaceController;

    private void Awake()
    {
        interfaceController = FindObjectOfType<InterfaceController>();
    }

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = Vector2.up * speed;
        currentVelocity = rigidBody.velocity;
    }

    private bool wasPaused = false;
    private Vector2 savedVelocity;

    private void Update()
    {
        rigidBody.velocity = rigidBody.velocity.normalized * speed;
        if (GameStateManager.Instance.isPaused)
        {
            if (!wasPaused)
            {
                // Store the current velocity before pausing the ball
                savedVelocity = rigidBody.velocity;
                rigidBody.velocity = Vector2.zero;
            }
            wasPaused = true;
        }
        else
        {
            if (wasPaused)
            {
                // Unpause the ball and set its velocity to the stored velocity
                rigidBody.velocity = savedVelocity;
            }
            wasPaused = false;
        }
    }



    // private void OnCollisionEnter2D(Collision2D other)
    // {
    //     Vector2 averageNormal = Vector2.zero;
    //     int contactCount = other.contactCount;

    //     for (int i = 0; i < contactCount; i++)
    //     {
    //         averageNormal += other.GetContact(i).normal;
    //     }

    //     averageNormal /= contactCount;
    //     Vector2 reflectDirection = Vector2.Reflect(currentVelocity.normalized, averageNormal);
    //     rigidBody.velocity = reflectDirection.normalized * speed;
    //     currentVelocity = rigidBody.velocity;
    // }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Add a small random value to the ball's velocity
        Vector2 randomDirection = new Vector2(Random.Range(-cornerVariance, cornerVariance), Random.Range(-cornerVariance, cornerVariance));
        rigidBody.velocity += randomDirection;

        // Normalize the ball's velocity to ensure it maintains its speed
        rigidBody.velocity = rigidBody.velocity.normalized * speed;
    }



}

