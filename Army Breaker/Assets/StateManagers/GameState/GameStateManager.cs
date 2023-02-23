using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance { get; private set; }

    //LevelSO Information
    public LevelSO currentLevelSO;
    public string currentLevelName;
    public ScoreHandler scoreHandler;
    public KingController kingController;

    public Scene gameScene;
    public string gameSceneName;
    public Scene menuScene;
    public string menuSceneName;



    public GameBaseState currentState;
    public GameMenuState MenuState = new GameMenuState();
    public GamePlayState PlayState = new GamePlayState();
    public GamePauseState PauseState = new GamePauseState();
    public GameOverState OverState = new GameOverState();
    public GameWonState WonState = new GameWonState();
    public GameTitleState TitleState = new GameTitleState();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(this.gameObject);

        gameScene = SceneManager.GetSceneByName("GameScene");
        menuScene = SceneManager.GetSceneByName("MenuScene");
    }
    
    void Start()
    {
        Debug.Log("GameStateManager Started");
        currentState = TitleState;
        currentState.EnterState(this);
    }

    void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(GameBaseState state)
    {
        currentState.ExitState(this);
        currentState = state;
        currentState.EnterState(this);
    }

    public void GetScoreHandler()
    {
        scoreHandler = FindObjectOfType<ScoreHandler>();
    }

    public void GetKingController()
    {
        kingController = FindObjectOfType<KingController>();
    }

    //Reset the values for the current level so we can't access level's from the any other scene
    public void ResetCurrentLevel()
    {
        Debug.Log("resetting current level");
        GameStateManager.Instance.currentLevelName = "";
        GameStateManager.Instance.currentLevelSO = null;
        GameManager.Instance.currentLevelController.currentLevelName = "";
    }
}
