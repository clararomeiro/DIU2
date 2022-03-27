using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField]
    private Text scoreCount;
    [SerializeField]
    private Text brainCount;

    [SerializeField]
    private PlayerMovement player;
    // Start is called before the first frame update
    void Start()
    {
        scoreCount.text = "0";
        brainCount.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        scoreCount.text = PlayerPrefs.GetInt("Score", 0).ToString();
        brainCount.text = player.getBrains().ToString();  
    }
}
