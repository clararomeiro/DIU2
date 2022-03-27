using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    // Start is called before the first frame update


    public void startGame(string gameName)
    {
        SceneManager.LoadScene(gameName);
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
