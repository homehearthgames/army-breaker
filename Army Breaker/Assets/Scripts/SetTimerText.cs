using UnityEngine;
using TMPro;

public class SetTimerText : MonoBehaviour
{
    TextMeshProUGUI timerText;
    InterfaceController interfaceController;

    private void Awake() {
        timerText = GetComponent<TextMeshProUGUI>();
        interfaceController = FindObjectOfType<InterfaceController>();
    }


    private void Update()
    {
        UpdateTimerText();
    }

    private void UpdateTimerText()
    {
        if (GameStateManager.Instance.isPaused)
        {
            return;
        }
        
        int minutes = (int)(GameManager.Instance.timeElapsed / 60f);
        int seconds = (int)(GameManager.Instance.timeElapsed % 60f);
        timerText.text = string.Format("{0:0}m {1:00}s", minutes, seconds);
    }
}
