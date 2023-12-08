using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void Start()
    {
       //GameObject.FindGameObjectWithTag("GameMusic").GetComponent<MusicClass>().PlayMusic();
    }

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
    }

    //quits gameMode
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
