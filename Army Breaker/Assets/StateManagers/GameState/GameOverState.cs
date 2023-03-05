using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverState : GameBaseState
{
    public override void EnterState(GameStateManager state)
    {
        Debug.Log("Entered Over State");
        state.GetScoreHandler();
        GameManager.Instance.timeElapsed = 0;
        state.scoreHandler.score = 0;
        state.isPaused = true;
    }
    public override void UpdateState(GameStateManager state)
    {
        
    }
    public override void ExitState(GameStateManager state)
    {
        state.isPaused = false;
    }
}
