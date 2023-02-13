using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TooltipManager : MonoBehaviour
{
    public static TooltipManager instance;
    [SerializeField] TextMeshProUGUI titleTextUGUI;
    [SerializeField] TextMeshProUGUI descriptionTextUGUI;

    private void Awake() {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetAndShowTooltip(string titleText, string descriptionText)
    {
        gameObject.SetActive(true);
        titleTextUGUI.text = titleText;
        descriptionTextUGUI.text = descriptionText;
    }

    public void HideTooltip()
    {
        gameObject.SetActive(false);
    }
}
