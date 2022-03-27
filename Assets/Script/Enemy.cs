using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private GameObject player;

    private Animator anim;

    private EnemySpawn spawn;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        anim = GetComponent<Animator>();
        spawn = FindObjectOfType<EnemySpawn>();

    }

    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, spawn.getVel() * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            PlayerPrefs.SetInt("EnemyKilled", PlayerPrefs.GetInt("EnemyKilled", 0)+1);
            PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score", 0) + 1);
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }

        if (collision.CompareTag("Player"))
        {
            anim.Play("Attack");
            if (PlayerPrefs.GetString("CanDie") == "true")
            {
                Destroy(collision.gameObject, 0.3f);
                FindObjectOfType<GameOver>().gameOver();
            }
        }
    }

}
