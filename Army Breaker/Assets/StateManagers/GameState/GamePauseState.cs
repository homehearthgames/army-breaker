using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePauseState : GameBaseState
{
    public override void EnterState(GameStateManager state)
    {
        Debug.Log("Entered the Pause State.");
        state.isPaused = true;
        Time.timeScale = 0;
    }
    public override void UpdateState(GameStateManager state)
    {
        
    }
    public override void ExitState(GameStateManager state)
    {
        state.isPaused = false;
        Time.timeScale = 1;
    }
}
