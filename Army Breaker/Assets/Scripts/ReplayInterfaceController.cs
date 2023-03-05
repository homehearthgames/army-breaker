using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReplayInterfaceController : MonoBehaviour
{
    [SerializeField] GameObject replayInterface;
    ScoreHandler scoreHandler;
    // Start is called before the first frame update
    void Start()
    {
        scoreHandler = FindObjectOfType<ScoreHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowAndHideReplayInterface()
    {
        Debug.Log("Showing Replay Interface");
        if (replayInterface.activeInHierarchy)
        {
            replayInterface.SetActive(false);
            GameStateManager.Instance.SwitchState(GameStateManager.Instance.PlayState);
        } else
        {
            replayInterface.SetActive(true);
            GameStateManager.Instance.SwitchState(GameStateManager.Instance.PauseState);
        }
    }


    public void ReplayLevel()
    {
        GameStateManager.Instance.PlayState.LoadGameScene(GameStateManager.Instance);
        GameManager.Instance.InstantiateLevel();
        GameStateManager.Instance.SwitchState(GameStateManager.Instance.PlayState);
        GameManager.Instance.timeElapsed = 0f;
    }
}
