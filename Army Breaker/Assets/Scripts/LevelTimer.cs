using UnityEngine;
using TMPro;

public class LevelTimer : MonoBehaviour
{
    private TextMeshProUGUI timerText;

    private float elapsedTime = 0f;

    private void Awake() {
        
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;
    }
}
