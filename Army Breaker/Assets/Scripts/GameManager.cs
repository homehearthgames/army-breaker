using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public float timeElapsed { get; set; }
    public CurrentLevelController currentLevelController;
    public AudioController audioController;
    public int currentAreaGridIndex = 0;


    private void Awake() {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
        currentLevelController = GetComponent<CurrentLevelController>();
        audioController = GetComponent<AudioController>();

    }

    public void UpdateTime()
    {
        timeElapsed += Time.deltaTime;
    }

    public void InstantiateLevel()
    {
        Instantiate(GameStateManager.Instance.currentLevelSO.gameGrid);
    }
}
