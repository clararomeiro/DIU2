using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField]
    private GameObject gameoverCanva;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gameoverCanva.SetActive(false);
        Time.timeScale = 1;
    }

    public void gameOver()
    {
        Invoke("gameOverWait", 0.2f);
    }

    public void gameOverWait()
    {
        gameoverCanva.SetActive(true);
        Time.timeScale = 0;
    }
}
