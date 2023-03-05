using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenuState : GameBaseState
{
    public override void EnterState(GameStateManager state)
    {
        Debug.Log("Entered Menu State");
        if (SceneManager.GetActiveScene() != SceneManager.GetSceneByName("MenuScene"))
        {
            SceneManager.LoadScene("MenuScene");
            Debug.Log("Loaded Scene " + SceneManager.GetActiveScene().name);
            state.StartCoroutine(WaitForSceneToLoad());
        }
        Debug.Log("Entered Scene " + SceneManager.GetActiveScene().name);
    }

    IEnumerator WaitForSceneToLoad()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("MenuScene");
        if (!asyncLoad.isDone)
        {
            yield return null;
        }
        GameManager.Instance.currentLevelController.CompleteLevel(GameStateManager.Instance.currentLevelName, GameManager.Instance.currentLevelController.levelComplete, GameManager.Instance.currentLevelController.bronzeMedal, GameManager.Instance.currentLevelController.silverMedal, GameManager.Instance.currentLevelController.goldMedal, GameManager.Instance.currentLevelController.timeAttackMedal);
        
        GameManager.Instance.timeElapsed = 0f;
    }

    public override void UpdateState(GameStateManager state)
    {
        
    }
    public override void ExitState(GameStateManager state)
    {
        Debug.Log("Exited Menu State");
    }


}
