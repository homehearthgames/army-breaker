using UnityEngine;
using UnityEngine.UI;

public class AudioHandler : MonoBehaviour
{
    // Enum to select which sound category to adjust the volume for
    public enum SoundCategory
    {
        InterfaceSounds,
        Music,
        GameSounds
    }


    private void OnEnable() {
        InitializeSliders();
    }

    // The sound category to adjust the volume for
    public SoundCategory soundCategory;

    // Reference to the slider UI element
    public Slider slider;


    // Called when we switch back to the title scene so the sliders are the same as the current settings
    public void InitializeSliders()
    {
        Debug.Log("Changig sounds");
        // Update the volume variable in the AudioController based on the selected sound category
        switch (soundCategory)
        {
            case SoundCategory.InterfaceSounds:
                slider.value = GameManager.Instance.audioController.interfaceSoundsVolume;
                
                Debug.Log("Changing music sounds");
                break;
            case SoundCategory.Music:
                slider.value = GameManager.Instance.audioController.musicVolume;
                
                Debug.Log("Changing interface sounds");
                Debug.Log(slider.value);
                break;
            case SoundCategory.GameSounds:
                slider.value = GameManager.Instance.audioController.gameSoundsVolume;
                break;
        }
    }

    // Called when the slider value is changed
    public void OnSliderValueChanged()
    {
        Debug.Log("Changig sounds");
        // Update the volume variable in the AudioController based on the selected sound category
        switch (soundCategory)
        {
            case SoundCategory.InterfaceSounds:
                GameManager.Instance.audioController.interfaceSoundsVolume = slider.value;
                
                Debug.Log("Changing music sounds");
                break;
            case SoundCategory.Music:
                GameManager.Instance.audioController.musicVolume = slider.value;
                
                Debug.Log("Changing interface sounds");
                Debug.Log(slider.value);
                break;
            case SoundCategory.GameSounds:
                GameManager.Instance.audioController.gameSoundsVolume = slider.value;
                break;
        }
    }
}
