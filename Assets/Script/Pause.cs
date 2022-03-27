using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{

    [SerializeField] private GameObject pauseScreen;
    // Start is called before the first frame update
    void Start()
    {
        pauseScreen.SetActive(false);

    }

    // Update is called once per frame

    public void pause()
    {
        pauseScreen.SetActive(true);
        Time.timeScale = 0;

    }

    public void resume()
    {
        pauseScreen?.SetActive(false);
        Time.timeScale = 1;
    }

    public void menu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }

    public void exit()
    {
        Application.Quit();
    }

   
}
