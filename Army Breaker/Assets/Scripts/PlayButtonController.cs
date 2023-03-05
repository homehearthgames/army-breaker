using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayButtonController : MonoBehaviour
{
    
    Button playButton;


    private void Start() {
        playButton = GetComponent<Button>();
    }
    // Update is called once per frame
    void Update()
    {
        if (GameStateManager.Instance.isPaused == false)
        {
            playButton.interactable = false;
        } else
        {
            playButton.interactable = true;
        }
    }
}
