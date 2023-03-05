using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButtonController : MonoBehaviour
{
    
    Button pauseButton;


    private void Start() {
        pauseButton = GetComponent<Button>();
    }
    // Update is called once per frame
    void Update()
    {
        if (GameStateManager.Instance.isPaused == true)
        {
            pauseButton.interactable = false;
        } else
        {
            pauseButton.interactable = true;
        }
    }
}
