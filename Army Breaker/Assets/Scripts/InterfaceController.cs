using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfaceController : MonoBehaviour
{
    public GameObject gameInterface;
    public GameObject loseInterface;
    public GameObject wonInterface;
    public GameObject pauseInterface;
    public GameObject replayInterface;
    private GameState currentState;


    // Start is called before the first frame update
    void Start()
    {
        currentState = GetGameState(GameStateManager.Instance.currentState);
        UpdateInterfaces();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameStateManager.Instance != null && GetGameState(GameStateManager.Instance.currentState) != currentState)
        {
            currentState = GetGameState(GameStateManager.Instance.currentState);
            UpdateInterfaces();
        }
    }

    private void UpdateInterfaces()
    {
        switch (currentState)
        {
            case GameState.PlayState:
                gameInterface.SetActive(true);
                loseInterface.SetActive(false);
                wonInterface.SetActive(false);
                pauseInterface.SetActive(false);
                replayInterface.SetActive(false);
                break;
            case GameState.OverState:
                gameInterface.SetActive(false);
                loseInterface.SetActive(true);
                wonInterface.SetActive(false);
                pauseInterface.SetActive(false);
                replayInterface.SetActive(false);
                break;
            case GameState.WonState:
                gameInterface.SetActive(false);
                loseInterface.SetActive(false);
                wonInterface.SetActive(true);
                pauseInterface.SetActive(false);
                replayInterface.SetActive(false);
                break;
            case GameState.PauseState:
                pauseInterface.SetActive(true);
                break;
            default:
                break;
        }
    }

    private GameState GetGameState(GameBaseState state)
    {
        if (state is GamePlayState)
        {
            return GameState.PlayState;
        }
        else if (state is GameOverState)
        {
            return GameState.OverState;
        }
        else if (state is GameWonState)
        {
            return GameState.WonState;
        }
        else if (state is GamePauseState)
        {
            return GameState.PauseState;
        }
        else
        {
            return GameState.Undefined;
        }
    }
}

public enum GameState
{
    Undefined,
    PlayState,
    OverState,
    WonState,
    PauseState
}
