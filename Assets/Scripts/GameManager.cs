using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    public static AudioSource source;

    private void Awake()
    {
        InitializeSingleton();

        if (!PlayerPrefs.HasKey("Difficulty"))
            PlayerPrefs.SetInt("Difficulty", 0);

        if (!PlayerPrefs.HasKey("Volume"))
            PlayerPrefs.SetFloat("Volume", (float) 0.5);

        if (!PlayerPrefs.HasKey("Fullscreen"))
            PlayerPrefs.SetInt("Fullscreen", 0);

        DBInterface dbint = new DBInterface(); 
    }

    private void Start()
    {
        source = GetComponent<AudioSource>();
        AudioListener.volume = PlayerPrefs.GetFloat("Volume");
        Screen.fullScreen = PlayerPrefs.GetInt("Fullscreen") == 1 ? true : false;
    }

    private void InitializeSingleton()
    {
        if (instance != null)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject); 
        }
    }

    public static void ChangeVolume(float newVolume)
    {
        AudioListener.volume = newVolume;
        PlayerPrefs.SetFloat("Volume", newVolume); 
    }

    public static void ChangeDifficulty(int difficulty)
    {
        PlayerPrefs.SetInt("Difficulty", difficulty); 
    }
}
