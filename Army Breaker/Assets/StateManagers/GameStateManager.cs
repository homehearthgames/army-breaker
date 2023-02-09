using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    GameBaseState currentState;
    public GameMenuState MenuState = new GameMenuState();
    public GamePlayState PlayState = new GamePlayState();
    public GamePauseState PauseState = new GamePauseState();
    public GameEndState EndState = new GameEndState();


    void Start()
    {
        currentState = MenuState;
        currentState.EnterState(this);
    }

    void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(GameBaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }
}
