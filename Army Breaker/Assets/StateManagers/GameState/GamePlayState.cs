using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayState : GameBaseState
{

    public override void EnterState(GameStateManager state)
    {
        Debug.Log("Entered Play State");
        if (SceneManager.GetActiveScene() != SceneManager.GetSceneByName("GameScene"))
        {
            SceneManager.LoadScene("GameScene");
            Debug.Log("Loading Scene " + SceneManager.GetSceneByName("GameScene").name);
            state.StartCoroutine(WaitForSceneToLoad());
        }
        else
        {
            Debug.Log("Entered Scene " + SceneManager.GetActiveScene().name);
        }
    }

    IEnumerator WaitForSceneToLoad()
    {

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("GameScene");
        if (!asyncLoad.isDone)
        {
            yield return null;
        }
        GameManager.Instance.InstantiateLevel();
        GameStateManager.Instance.GetKingController();
        
        //Make sure the level doesn't start marked as completed
        GameManager.Instance.currentLevelController.levelComplete = false;
        GameManager.Instance.currentLevelController.bronzeMedal = false;
        GameManager.Instance.currentLevelController.silverMedal = false;
        GameManager.Instance.currentLevelController.goldMedal = false;
        GameManager.Instance.currentLevelController.timeAttackMedal = false;
    }

    public override void UpdateState(GameStateManager state)
    {
        if (state.kingController != null)
        {
            if (state.kingController.enemyKingsSlain)
            {
                state.SwitchState(state.WonState);
            }
        }
        
        if (state.kingController != null)
        {
            if (state.kingController.playerKingsSlain)
            {
                state.SwitchState(state.OverState);
            }
        }

        GameManager.Instance.UpdateTime();
    }
    public override void ExitState(GameStateManager state)
    {
        
    }
}
