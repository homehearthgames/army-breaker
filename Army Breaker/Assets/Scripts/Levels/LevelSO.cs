using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "LevelSO", menuName = "Army Breaker/LevelSO", order = 0)]
public class LevelSO : ScriptableObject {
    public bool levelComplete;
    public GameObject gameGrid;
    public Sprite levelPreviewImage;
    public string levelTitleText;

    public bool timeAttackComplete;
    public float timeAttackTime;

    public string bronzeMedalTitleText, bronzeMedalDescriptionText;
    public string silverMedalTitleText, silverMedalDescriptionText;
    public int bronzeMedalPointRequirement;
    public int silverMedalPointRequirement;
    public int goldMedalPointRequirement;
    public string goldMedalTitleText, goldMedalDescriptionText;
    public bool bronzeMedalEarned, silverMedalEarned, goldMedalEarned;
}
