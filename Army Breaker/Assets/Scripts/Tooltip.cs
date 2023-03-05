using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tooltip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public enum DescriptionType {
        Bronze,
        Silver,
        Gold,
        TimeAttack
    }

    public DescriptionType descriptionType;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (GameStateManager.Instance.currentLevelSO != null)
        {
            string descriptionText = "";
            string titleText = "";

            switch (descriptionType)
            {
                case DescriptionType.Bronze:
                    descriptionText = $"Earn {GameStateManager.Instance.currentLevelSO.bronzeMedalPointRequirement} points and finish the level to earn the Bronze Medal!";
                    titleText = "Bronze Medal";
                    break;
                case DescriptionType.Silver:
                    descriptionText = $"Earn {GameStateManager.Instance.currentLevelSO.silverMedalPointRequirement} points and finish the level to earn the Silver Medal!";
                    titleText = "Silver Medal";
                    break;
                case DescriptionType.Gold:
                    descriptionText = $"Earn {GameStateManager.Instance.currentLevelSO.goldMedalPointRequirement} points and finish the level to earn the Gold Medal!";
                    titleText = "Gold Medal";
                    break;
                case DescriptionType.TimeAttack:
                    descriptionText = "Complete the level within the time limit to earn this medal.";
                    string timeFormatted = String.Format("{0:0}m {1:00}s", Mathf.Floor(GameStateManager.Instance.currentLevelSO.timeAttackTime / 60), GameStateManager.Instance.currentLevelSO.timeAttackTime % 60);
                    titleText = timeFormatted;

                    break;
            }

            TooltipManager.instance.SetAndShowTooltip(titleText, descriptionText);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        TooltipManager.instance.HideTooltip();
    }
}
