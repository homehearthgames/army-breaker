using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PreviewLevelTitleSetter : MonoBehaviour
{
    TextMeshProUGUI previewTitleText;

    // Start is called before the first frame update
    void Start()
    {
        previewTitleText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        SetPreviewLevelTitleText();
    }

    private void SetPreviewLevelTitleText()
    {
        if (GameStateManager.Instance.currentLevelSO != null)
        {
            previewTitleText.text = GameStateManager.Instance.currentLevelSO.levelTitleText;
        } else
        {
            previewTitleText.text = "Choose a Level!";
        }
    }
}
