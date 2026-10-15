using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{   
    public float speed = 5f;
    public float powerJump = 10f;
    bool onFloor = true;
    bool walk = true;

    public Rigidbody2D rb;
    public SpriteRenderer sr;
    
    public Sprite jumping;
    public Sprite standing;
    public Sprite walking;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;

        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space) && onFloor)
        {
            rb.linearVelocityY = powerJump;
            onFloor = false;
        }

        else if(Input.GetKey(KeyCode.RightArrow))
        {
            rb.linearVelocityX = speed;
            sr.sprite = walking;
            sr.flipX = false;
            walk = true;
        }

        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.linearVelocityX = -speed;
            sr.sprite = walking;
            sr.flipX = true;
            walk = true;
        }

        else if (!walk && !onFloor)
        {   
            sr.sprite = jumping;
        }

        else
        {
            sr.sprite=standing;
            rb.linearVelocityX = 0;
            walk = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {      
            onFloor = true;
        }
    }

    private void OnTgerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Dead"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }       
    }
}