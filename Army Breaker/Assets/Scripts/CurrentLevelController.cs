using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelDataClass
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
    public List<LevelDataClass> levelDataList = new List<LevelDataClass>();

    public void CompleteLevel(string levelName,bool levelCompleted, bool bronzeMedal, bool silverMedal, bool goldMedal, bool timeAttackMedal)
    {
            LevelDataClass levelDataClass = levelDataList.Find(x => x.levelName == levelName);
            if (levelDataClass == null)
            {
                levelDataClass = new LevelDataClass();
                levelDataClass.levelName = levelName;
                levelDataList.Add(levelDataClass);
            }


            if (levelComplete)
            {
                
                if (levelCompleted && (!levelDataClass.levelCompleted))
                {
                    levelDataClass.levelCompleted = true;
                }

                if (bronzeMedal && (!levelDataClass.bronzeMedalEarned || !levelDataClass.silverMedalEarned || !levelDataClass.goldMedalEarned))
                {
                    levelDataClass.bronzeMedalEarned = true;
                }

                if (silverMedal && (!levelDataClass.silverMedalEarned || !levelDataClass.goldMedalEarned))
                {
                    levelDataClass.silverMedalEarned = true;
                }

                if (goldMedal && !levelDataClass.goldMedalEarned)
                {
                    levelDataClass.goldMedalEarned = true;
                }
                levelDataClass.timeAttackMedalEarned = timeAttackMedal;
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
