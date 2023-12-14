using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //starts gameMode
    public void PlayGame(int gameMode = 1)
    {
        if (gameMode == 1)
        {
            SceneManager.LoadScene("player");
        }
        if (gameMode == 0)
        {
            SceneManager.LoadScene("Menu");
        }
        if (gameMode == 2)
        {
            SceneManager.LoadScene("NoNoSpider");
        }
    }

    //quits gameMode
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    //resets game, just starts it again
    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
