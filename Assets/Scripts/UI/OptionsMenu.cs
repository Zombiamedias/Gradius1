using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour {
    public Slider slider;
    public float volumeValue;
    public Image imgMute;
    public AudioMixer audioMixer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        
        CheckMute();
    }
    public void ChangeSlider(float volume){
        volumeValue = volume;
        audioMixer.SetFloat("Volume", volume);
        CheckMute();
    }
    public void CheckMute()
    {
        if (volumeValue == -80)
        {
            imgMute.enabled = true;
        }
        else
        {
            imgMute.enabled = false;
        }
    }
    public void SetFullScreen(bool isFullscreen){
        Screen.fullScreen = isFullscreen;
    }
}