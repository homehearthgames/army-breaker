using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Define a struct to store level progress data
public struct LevelProgress {
    public MedalType medal;
    public float time;
}

public enum MedalType {
    None,
    Bronze,
    Silver,
    Gold
}

public static class ProgressManager {

    // Save level progress data to PlayerPrefs
    public static void SaveLevelProgress(string level, LevelProgress progress) {
        string key = "Level_" + level;
        PlayerPrefs.SetString(key, JsonUtility.ToJson(progress));
    }

    // Load level progress data from PlayerPrefs
    public static LevelProgress LoadLevelProgress(string level) {
        string key = "Level_" + level;
        if(PlayerPrefs.HasKey(key)) {
            return JsonUtility.FromJson<LevelProgress>(PlayerPrefs.GetString(key));
        }
        return new LevelProgress();
    }

}

