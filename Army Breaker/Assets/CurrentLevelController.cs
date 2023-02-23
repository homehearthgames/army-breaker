using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelData
{
    public string levelName;
    public bool levelCompleted;
    public bool bronzeMedalEarned;
    public bool silverMedalEarned;
    public bool goldMedalEarned;
    public bool timeAttackMedalEarned;
}

public class CurrentLevelController : MonoBehaviour
{
    public LevelHandler[] levelHandlers;
    public string currentLevelName;
    public bool levelComplete;
    public bool bronzeMedal, silverMedal, goldMedal, timeAttackMedal;
    public List<LevelData> levelDataList = new List<LevelData>();

    public void CompleteLevel(string levelName,bool levelCompleted, bool bronzeMedal, bool silverMedal, bool goldMedal, bool timeAttackMedal)
    {
            LevelData levelData = levelDataList.Find(x => x.levelName == levelName);
            if (levelData == null)
            {
                levelData = new LevelData();
                levelData.levelName = levelName;
                levelDataList.Add(levelData);
            }


            if (levelComplete)
            {
                
                if (levelCompleted && (!levelData.levelCompleted))
                {
                    levelData.levelCompleted = true;
                }

                if (bronzeMedal && (!levelData.bronzeMedalEarned || !levelData.silverMedalEarned || !levelData.goldMedalEarned))
                {
                    levelData.bronzeMedalEarned = true;
                }

                if (silverMedal && (!levelData.silverMedalEarned || !levelData.goldMedalEarned))
                {
                    levelData.silverMedalEarned = true;
                }

                if (goldMedal && !levelData.goldMedalEarned)
                {
                    levelData.goldMedalEarned = true;
                }
                levelData.timeAttackMedalEarned = timeAttackMedal;
            }
            DistributeLevelInformation();
        
    }

    public void DistributeLevelInformation()
    {
        levelHandlers = FindObjectsOfType<LevelHandler>();
        foreach (var level in levelDataList)
        {
            foreach (var levelHandler in levelHandlers)
            {
                if (levelHandler.levelName == level.levelName)
                {
                    Debug.Log(levelHandler.name);
                    if (level.levelCompleted)
                    {
                        levelHandler.levelComplete = true;
                    }
                    if (level.bronzeMedalEarned)
                    {
                        levelHandler.bronzeMedalEarned = level.bronzeMedalEarned;
                    }
                    if (level.silverMedalEarned)
                    {
                        levelHandler.silverMedalEarned = level.silverMedalEarned;
                    }
                    if (level.goldMedalEarned)
                    {
                        levelHandler.goldMedalEarned = level.goldMedalEarned;
                    }
                    if (level.timeAttackMedalEarned)
                    {
                        levelHandler.timeAttackMedalEarned = level.timeAttackMedalEarned;
                    }
                    levelHandler.ChangeMedalSprites();
                    levelHandler.ChangeLevelSprite();
                }
            }
        }
    }
}
