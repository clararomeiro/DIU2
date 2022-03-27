using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrainSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] brainPos;

    [SerializeField]
    private GameObject brainPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(PlayerPrefs.GetInt("EnemyKilled", 0) > 4)
        {
            int pos = Random.Range(0, brainPos.Length);
            Instantiate(brainPrefab, brainPos[pos].transform.position, Quaternion.identity);
            PlayerPrefs.SetInt("EnemyKilled", 0);

        }
    }
}
