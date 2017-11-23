using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonEvents : MonoBehaviour {

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }

    public void NewGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Settings()
    {
        SceneManager.LoadScene("Settings"); 
    }

    public void EasyDifficulty()
    {
        GameManager.ChangeDifficulty(-1); 
    }

    public void MediumDifficulty()
    {
        GameManager.ChangeDifficulty(0); 
    }

    public void HardDifficulty()
    {
        GameManager.ChangeDifficulty(1); 
    }

    public void Exit()
    {
        Application.Quit(); 
    }
}
