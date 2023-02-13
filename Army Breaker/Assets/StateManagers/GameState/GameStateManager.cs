using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance { get; private set; }

    GameBaseState currentState;
    public GameMenuState MenuState = new GameMenuState();
    public GamePlayState PlayState = new GamePlayState();
    public GamePauseState PauseState = new GamePauseState();
    public GameOverState OverState = new GameOverState();
    public GameWonState WonState = new GameWonState();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
    }
    
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
