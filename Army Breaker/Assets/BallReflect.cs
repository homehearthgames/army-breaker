using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallReflect : MonoBehaviour
{
    public float hitStopDuration = 0.05f;
    public float hitStopTimeScale = 0.1f;

    [SerializeField] Transform playerTransform; // Reference to the player's transform

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
            Rigidbody2D ballRigidbody = other.GetComponent<Rigidbody2D>();

            // Calculate the direction from the ball to the player's position
            Vector2 ballToPlayer = (Vector2)playerTransform.position - ballRigidbody.position;
            ballRigidbody.velocity = -ballToPlayer.normalized * ballRigidbody.velocity.magnitude;

            StartCoroutine(HitStopCoroutine());
        }
    }

    IEnumerator HitStopCoroutine()
    {
        // Pause the game for hitStopDuration seconds
        Time.timeScale = hitStopTimeScale;
        yield return new WaitForSecondsRealtime(hitStopDuration);
        CinemachineShake.Instance.ShakeCamera(1f, .1f);
        Time.timeScale = 1f;
    }
}
