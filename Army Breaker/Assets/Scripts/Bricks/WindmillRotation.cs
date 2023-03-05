using UnityEngine;

public class WindmillRotation : MonoBehaviour
{
    [SerializeField] private float minRotationSpeed = 10f;
    [SerializeField] private float maxRotationSpeed = 20f;
    [SerializeField] private float lerpSpeed = 0.1f;
    private float targetRotationSpeed;
    private float currentRotationSpeed;

    private void Start()
    {
        // Set the initial rotation speed to a random value between minRotationSpeed and maxRotationSpeed.
        targetRotationSpeed = Random.Range(minRotationSpeed, maxRotationSpeed);
        currentRotationSpeed = targetRotationSpeed;
    }

    private void Update()
    {
        // LERP the current rotation speed towards the target rotation speed.
        currentRotationSpeed = Mathf.Lerp(currentRotationSpeed, targetRotationSpeed, lerpSpeed * Time.deltaTime);

        // Rotate the object on its Z axis with the current rotation speed.
        transform.Rotate(Vector3.forward * currentRotationSpeed * Time.deltaTime);

        // If the difference between the current and target rotation speed is small, set a new random target speed.
        if (Mathf.Abs(currentRotationSpeed - targetRotationSpeed) < 0.1f)
        {
            targetRotationSpeed = Random.Range(minRotationSpeed, maxRotationSpeed);
        }
    }
}
