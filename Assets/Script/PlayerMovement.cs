using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player")]
    [SerializeField]
    private Rigidbody2D rb;

    [Header("Movement Config")]
    [SerializeField]
    private float vel;
    private float xdir;
    [SerializeField]
    private float jumpforce;

    [Header("Animation Config")]
    [SerializeField]
    private Animator playeranim;

    [Header("Box")]
    [SerializeField]
    private GameObject box;
    [SerializeField]
    private Sprite coffin;

    private bool canJump;

    private Vector3 left;
    private Vector3 right;

    private bool attack = false;
    private bool isCoffin = false;

    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private GameObject bulletPlace;

    // Start is called before the first frame update
    void Start()
    {
        right = transform.localScale;
        left = transform.localScale;
        left.x *= -1;
    }

    // Update is called once per frame
    void Update()
    {
        xdir = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(xdir * vel, rb.velocity.y);

        if(xdir < 0)
        {
            transform.localScale = left;
        }
        else
        {
            transform.localScale = right;
        }

        if (rb.velocity.x != 0)
        {
            playeranim.SetBool("walking", true);
        }
        else
        {
            playeranim.SetBool("walking", false);
        }

        if (Input.GetButton("Jump") && canJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpforce);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            playeranim.Play("attack");
            attack = true;
            Instantiate(bullet, bulletPlace.transform.position, this.gameObject.transform.rotation);
        }
        else
        {
            playeranim.SetBool("attack", false);
            attack = false;
        }

        if (isCoffin)
        {
            Application.Quit();
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Box") && attack)
        {
            box.GetComponent<SpriteRenderer>().sprite = coffin;
            box.transform.localScale = new Vector3(2, 2, 2);
            box.GetComponent<BoxCollider2D>().size = new Vector2(1, 0.52f);
            Invoke("turnCoffin", 1);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.CompareTag("Floor"))
        {
            canJump = true;
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Floor"))
        {
            canJump = false;
        }
    }

    public void turnCoffin()
    {
        Debug.Log("in");

        isCoffin = true;
    }
}
