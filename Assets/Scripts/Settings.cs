using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Settings : MonoBehaviour {

    public Slider volumeSlider;
    public Text fullscreenText; 
    
	void Start () {
        volumeSlider.value = PlayerPrefs.GetFloat("Volume");
        fullscreenText.text = GetFullscreenStatus();
    }

    public void OnVolumeChange()
    {
        GameManager.ChangeVolume(volumeSlider.value);
    }

    public void ToggleFullScreen(){

        if (PlayerPrefs.GetInt("Fullscreen") == 0)
        {
            PlayerPrefs.SetInt("Fullscreen", 1);
            Screen.fullScreen = true;
            fullscreenText.text = "On"; 
        }
        else
        {
            PlayerPrefs.SetInt("Fullscreen", 0);
            Screen.fullScreen = false;
            fullscreenText.text = "Off"; 
        }

        fullscreenText.text = GetFullscreenStatus(); 
    }

    private string GetFullscreenStatus()
    {
        if (PlayerPrefs.GetInt("Fullscreen") == 1)
            return "On"; 
        else
            return "Off"; 
    }
}
