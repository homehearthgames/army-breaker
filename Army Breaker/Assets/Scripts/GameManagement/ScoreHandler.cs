using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreHandler : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI scoreText;
    public Image comboImage;
    public TextMeshProUGUI comboText;

    public float currentComboPercentage = 0;
    public float currentTimer = 0;
    public float maxTimer = 10f;

    public float x1Threshold = 10f;
    public float x2Threshold = 45f;
    public float x4Threshold = 85f;

    public int x1Multiplier = 1;
    public int x2Multiplier = 2;
    public int x4Multiplier = 4;
    public int x8Multiplier = 8;

    public float timerStep = 2f;

    public int comboValue;

    private void Update()
    {
        currentTimer -=  timerStep * Time.deltaTime;
        currentTimer = Mathf.Clamp(currentTimer, 0, maxTimer);
        currentComboPercentage = (currentTimer / maxTimer) * 100;
        comboImage.fillAmount = currentTimer / maxTimer;
        comboValue = SetCombo();
        
        SetText();
    }

    public void SetText()
    {
        comboText.text = "x" + SetCombo().ToString();
        scoreText.text = score.ToString("D7");
    }

    public float AddToComboBuilder(float timeToAdd)
    {
        return currentTimer += timeToAdd;
    }

    public int SetCombo()
    {
        if (currentComboPercentage >= 0 && currentComboPercentage <= x1Threshold)
        {
            Debug.Log("x1 Combo!");
            return x1Multiplier;
        }
        else if (currentComboPercentage > x1Threshold && currentComboPercentage <= x2Threshold)
        {
            Debug.Log("x2 Combo!");
            return x2Multiplier;
        }
        else if (currentComboPercentage > x2Threshold && currentComboPercentage <= x4Threshold)
        {
            Debug.Log("x4 Combo!");
            return x4Multiplier;
        }
        else
        {
            Debug.Log("x8 Combo!");
            return x8Multiplier;
        }
    }

    public void AddPoints(int pointsToAdd)
    {
        score += pointsToAdd * comboValue;
    }
}
