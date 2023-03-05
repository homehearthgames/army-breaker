using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleNavigationController : MonoBehaviour
{
    public GameObject titleInterface;
    public GameObject optionsInterface;
    
    void Start()
    {
        titleInterface.SetActive(true);
        optionsInterface.SetActive(false);
    }

    void Update()
    {
        
    }

    public void ShowTitleInterface()
    {
        titleInterface.SetActive(true);
        optionsInterface.SetActive(false);
        GameManager.Instance.audioController.PlayInterfaceSound(AudioController.Sound.ButtonClick);
    }

    public void ShowOptionsInterface()
    {
        titleInterface.SetActive(false);
        optionsInterface.SetActive(true);
        GameManager.Instance.audioController.PlayInterfaceSound(AudioController.Sound.ButtonClick);  
    }
}
