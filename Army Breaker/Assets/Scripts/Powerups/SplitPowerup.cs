using UnityEngine;

public class SplitPowerup : MonoBehaviour
{
    public float splitForce = 5f; // The force to apply to the new ball when spawned

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
            // Clone the current ball
            GameObject newBall = Instantiate(other.gameObject, other.transform.position, Quaternion.identity);

            // Apply a random force to the new ball
            Vector2 splitDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
            newBall.GetComponent<Rigidbody2D>().AddForce(splitDirection * splitForce, ForceMode2D.Impulse);

            // Destroy the powerup
            Destroy(gameObject);
        }
    }
}
