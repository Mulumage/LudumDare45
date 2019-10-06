using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
    
    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }
    
    public void LoadCredits()
    {
        SceneManager.LoadScene("Credits");
    }
    
    public void LoadHighscores()
    {
        SceneManager.LoadScene("Highscores");
    } 
    
    public void LoadGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
