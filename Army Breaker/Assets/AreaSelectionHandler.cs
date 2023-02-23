using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AreaSelectionHandler : MonoBehaviour
{
    public GameObject area;
    public GameObject areaChild;
    public GameObject currentArea;
    public AreaSelectionController areaSelectionController;

    //Level Preview Elements
    [SerializeField] public TextMeshProUGUI levelTitleText;
    [SerializeField] public Image levelPreviewImage;
    [SerializeField] public Image bronzeMedalImage, silverMedalImage, goldMedalImage;
    [SerializeField] public Image timeAttackMedalImage;

void Start()
{
    // Find the object with the AreaSelectionController script and get a reference to it
    areaSelectionController = FindObjectOfType<AreaSelectionController>();

    // Loop through each GameObject in the areaList array
    for (int i = 0; i < areaSelectionController.areaList.Length; i++)
    {
        area = areaSelectionController.areaList[i];

        // Instantiate a new child GameObject based on the area GameObject, and disable it
        areaChild = Instantiate(area, transform);
        areaChild.name = area.name;
        areaChild.SetActive(false);
    }

    // Activate the child GameObject corresponding to the currently selected area
    UpdateSelectedArea();
}


    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void UpdateSelectedArea()
    {
        // Disable all child GameObjects
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }

        // Activate the child GameObject corresponding to the currently selected area
        currentArea = areaSelectionController.currentAreaGrid;
        foreach (Transform child in transform)
        {
            if (child.name == currentArea.name)
            {
                child.gameObject.SetActive(true);
            }
        }
    }
}
