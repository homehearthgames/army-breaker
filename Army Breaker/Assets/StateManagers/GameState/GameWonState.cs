using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWonState : GameBaseState
{
    public override void EnterState(GameStateManager state)
    {
        Debug.Log("Entered Won State");
        state.GetScoreHandler();
        GameManager.Instance.currentLevelController.levelComplete = true;
        if(GameManager.Instance.timeElapsed <= state.currentLevelSO.timeAttackTime)
        {
            GameManager.Instance.currentLevelController.timeAttackMedal = true;
        }
        if (state.scoreHandler.score >= state.currentLevelSO.bronzeMedalPointRequirement)
        {
            GameManager.Instance.currentLevelController.bronzeMedal = true;
        }
        if (state.scoreHandler.score >= state.currentLevelSO.silverMedalPointRequirement)
        {
            GameManager.Instance.currentLevelController.silverMedal = true;
        }
        if (state.scoreHandler.score >= state.currentLevelSO.goldMedalPointRequirement)
        {
            GameManager.Instance.currentLevelController.goldMedal = true;
        }
        Debug.Log("Score for this level: " + state.scoreHandler.score);
        GameManager.Instance.timeElapsed = 0;
        state.scoreHandler.score = 0;
    }
    public override void UpdateState(GameStateManager state)
    {
        
    }
    public override void ExitState(GameStateManager state)
    {
        
    }
}
