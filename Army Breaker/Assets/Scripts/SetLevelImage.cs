using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetLevelImage : MonoBehaviour
{
    Image currentLevelPreviewImage;
    [SerializeField] Sprite incompleteMedalSprite;
    [SerializeField] Sprite incompleteTimeAttackMedalSprite;
    [SerializeField] Image bronzeMedalImage;
    [SerializeField] Image silverMedalImage;
    [SerializeField] Image goldMedalImage;
    [SerializeField] Image timeAttackMedalImage;
    [SerializeField] Sprite noLevelSelectedImage;
    
    void Start()
    {
        currentLevelPreviewImage = GetComponent<Image>();
    }

    void Update()
    {
        //If there is a level selected, set the current level preview image to the level SO's
        if (GameStateManager.Instance.currentLevelSO != null)
        {
            currentLevelPreviewImage.GetComponent<Image>().type = Image.Type.Simple;
            currentLevelPreviewImage.sprite = GameStateManager.Instance.currentLevelSO.levelPreviewImage;
        } 
        //If there's no level selected, set the preview level window to default
        else
        {
            
            currentLevelPreviewImage.GetComponent<Image>().type = Image.Type.Tiled;
            currentLevelPreviewImage.sprite = noLevelSelectedImage;
            bronzeMedalImage.sprite = incompleteMedalSprite;
            silverMedalImage.sprite = incompleteMedalSprite;
            goldMedalImage.sprite = incompleteMedalSprite;
            timeAttackMedalImage.sprite = incompleteTimeAttackMedalSprite;
        }
    }
}
