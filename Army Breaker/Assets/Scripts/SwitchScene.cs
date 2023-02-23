using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    GameStateManager gameStateManager;
    // Start is called before the first frame update
    void Start()
    {
        gameStateManager = GameStateManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchToGameScene()
    {
        if (GameStateManager.Instance.currentLevelSO != null)
        {
            gameStateManager.SwitchState(gameStateManager.PlayState);
            GameManager.Instance.audioController.PlayInterfaceSound(AudioController.Sound.ButtonClick);
        }
        
    }
    public void SwitchToMenuScene()
    {
        gameStateManager.SwitchState(gameStateManager.MenuState);
            GameManager.Instance.audioController.PlayInterfaceSound(AudioController.Sound.ButtonClick);
    }

    public void SwitchToPauseScene()
    {
        gameStateManager.SwitchState(gameStateManager.PauseState);
            GameManager.Instance.audioController.PlayInterfaceSound(AudioController.Sound.ButtonClick);
    }

    
    public void SwitchToTitleScene()
    {
        gameStateManager.SwitchState(gameStateManager.TitleState);
            GameManager.Instance.audioController.PlayInterfaceSound(AudioController.Sound.ButtonClick);
    }
    
}
