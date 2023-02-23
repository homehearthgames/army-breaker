using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelHandler : MonoBehaviour
{
    public string levelName;
    public bool levelComplete;
    public bool bronzeMedalEarned;
    public bool silverMedalEarned;
    public bool goldMedalEarned;
    public bool timeAttackMedalEarned;
    // [SerializeField] Image levelPreviewImage;

    [SerializeField] Sprite levelCompleteSprite;
    [SerializeField] Sprite levelIncompleteSprite;
    [SerializeField] Image currentLevelImage;

    // [SerializeField] Image bronzeMedalImage, silverMedalImage, goldMedalImage;
    [SerializeField] Sprite bronzeMedalSprite, silverMedalSprite, goldMedalSprite;


    // [SerializeField] Image timeAttackMedalImage;
    [SerializeField] Sprite timeAttackCompleteSprite;
    [SerializeField] Sprite timeAttackIncompleteSprite;

    [SerializeField] LevelSO levelSO;

    AreaSelectionHandler areaSelectionHandler;


    void Awake()
    {
        areaSelectionHandler = GetComponentInParent<AreaSelectionHandler>();
    }


    public void ChooseLevel()
    {
        GameManager.Instance.audioController.PlayInterfaceSound(AudioController.Sound.ButtonClick);
        
        GameManager.Instance.currentLevelController.DistributeLevelInformation();
        //Set level SO and Name
        GameStateManager.Instance.currentLevelSO = levelSO;
        GameManager.Instance.currentLevelController.currentLevelName = levelName;
        GameStateManager.Instance.currentLevelName = levelName;
        
        //Set level preview Image
        areaSelectionHandler.levelPreviewImage.sprite = levelSO.levelPreviewImage;

        ChangeMedalSprites();
    }

    public void ChangeLevelSprite()
    {
        //Set level grid icon (Complete/Incomplete)
        if (levelComplete)
        {
            currentLevelImage.sprite = levelCompleteSprite;
        }
        else if (!levelComplete)
        {
            currentLevelImage.sprite = levelIncompleteSprite;
        }
    }
    
    public void ChangeMedalSprites()
    {
        //Set medals (Complete/Incomplete)
        if (bronzeMedalEarned)
        {
            areaSelectionHandler.bronzeMedalImage.sprite = bronzeMedalSprite;
        } else if (!bronzeMedalEarned)
        {
            areaSelectionHandler.bronzeMedalImage.sprite = levelIncompleteSprite;
        }
        if (silverMedalEarned)
        {
            areaSelectionHandler.silverMedalImage.sprite = silverMedalSprite;
        } else if (!silverMedalEarned)
        {
            areaSelectionHandler.silverMedalImage.sprite = levelIncompleteSprite;
        }
        if (goldMedalEarned)
        {
            areaSelectionHandler.goldMedalImage.sprite = goldMedalSprite;
        } else if (!goldMedalEarned)
        {
            areaSelectionHandler.goldMedalImage.sprite = levelIncompleteSprite;
        }
        if (timeAttackMedalEarned)
        {
            areaSelectionHandler.timeAttackMedalImage.sprite = timeAttackCompleteSprite;
        } else if (!timeAttackMedalEarned)
        {
            areaSelectionHandler.timeAttackMedalImage.sprite = timeAttackIncompleteSprite;
        }
    }
}
