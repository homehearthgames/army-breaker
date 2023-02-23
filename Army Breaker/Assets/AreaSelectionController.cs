using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AreaSelectionController : MonoBehaviour
{
    public GameObject[] areaList;
    [SerializeField] public GameObject currentAreaGrid;
    [SerializeField] TextMeshProUGUI areaTitleText;
    private int currentIndex;


    public AreaSelectionHandler areaSelectionHandler;

    // Start is called before the first frame update
    void Start()
    {
        currentIndex = GameManager.Instance.currentAreaGridIndex;
        currentAreaGrid = areaList[currentIndex];
        areaSelectionHandler.UpdateSelectedArea();
    }

    // Update is called once per frame
    void Update()
    {
        GameManager.Instance.currentAreaGridIndex = currentIndex;
        areaTitleText.text = currentAreaGrid.name;
    }

    public void SwitchToNextArea()
    {
        GameManager.Instance.audioController.PlayInterfaceSound(AudioController.Sound.ButtonClick);
        currentIndex = (currentIndex + 1) % areaList.Length;
        currentAreaGrid = areaList[currentIndex];
        areaSelectionHandler.UpdateSelectedArea();
        GameStateManager.Instance.currentLevelSO = null;
        GameStateManager.Instance.currentLevelName = null;
        GameManager.Instance.currentLevelController.DistributeLevelInformation();
    }

    public void SwitchToPreviousArea()
    {
        GameManager.Instance.audioController.PlayInterfaceSound(AudioController.Sound.ButtonClick);
        currentIndex = (currentIndex - 1 + areaList.Length) % areaList.Length;
        currentAreaGrid = areaList[currentIndex];
        areaSelectionHandler.UpdateSelectedArea();
        GameStateManager.Instance.currentLevelSO = null;
        GameStateManager.Instance.currentLevelName = null;
        GameManager.Instance.currentLevelController.DistributeLevelInformation();
    }
}
