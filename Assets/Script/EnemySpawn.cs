using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject[] spawnPositions;

    [SerializeField]
    private GameObject enemy;

    private int round;
    private float tempo;
    private float limit;
    private float vel;

    // Start is called before the first frame update
    void Start()
    {
        round = 0;
        limit = 3f;
        tempo = 0;
        vel = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        tempo = tempo + Time.deltaTime;

        if(tempo > limit)
        {
            int pos = Random.Range(0, spawnPositions.Length);
            enemy.transform.localScale = spawnPositions[pos].transform.localScale;
            Instantiate(enemy, spawnPositions[pos].transform.position, Quaternion.identity);
            round = round + 1;

            if(round == 3 && limit > 0.4f)
            {
                limit = limit - 0.1f;
                vel = vel + 0.3f;
                round = 0;
            }

            tempo = 0;
        }

        Debug.Log(limit);
        
    }

    public float getVel()
    {
        return vel;
    }
}
