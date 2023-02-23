using System.Collections;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed = 5f;
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

    private void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Vector2 averageNormal = Vector2.zero;
        int contactCount = other.contactCount;

        for (int i = 0; i < contactCount; i++)
        {
            averageNormal += other.GetContact(i).normal;
        }

        averageNormal /= contactCount;
        Vector2 reflectDirection = Vector2.Reflect(currentVelocity.normalized, averageNormal);
        rigidBody.velocity = reflectDirection.normalized * speed;
        currentVelocity = rigidBody.velocity;
    }
}

