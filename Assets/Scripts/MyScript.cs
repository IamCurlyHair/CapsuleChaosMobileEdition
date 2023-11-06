using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MyScript : MonoBehaviour
{
    protected Joystick joystick;
    protected JoyButton joybutton;
    protected bool jump;
    private bool isGrounded;
    private float jumpforce = 15f;
    private float moveforce = 6f;
    public GameObject MenuUI;
    public GameObject PauseMenuUI;

    // Start is called before the first frame update
    void Start()
    {
        joystick = FindObjectOfType<Joystick>();
        joybutton = FindObjectOfType<JoyButton>();
    }

    // Update is called once per frame
    void Update()
    {
        var rigidBody = GetComponent<Rigidbody2D>();

        rigidBody.velocity = new Vector2(joystick.Horizontal * moveforce, rigidBody.velocity.y);

        if(!jump && joybutton.Pressed)
        {
            jump = true;
            rigidBody.velocity += Vector2.up * jumpforce;
            
            
        }
        if(jump && !joybutton.Pressed)
        {
            jump = false;
            

        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        jumpforce = 15f;

        if(collision.gameObject.tag == "Slippery")
        {
            moveforce = 2f;
            jumpforce = 8f;
        }
        if(collision.gameObject.tag == "Death")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Score.theScore = 0;
        }
       

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        jumpforce = 0f;

        if (collision.gameObject.tag == "Slippery")
        {
            moveforce = 6f;
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Points")
        {
            FindObjectOfType<AudioManager>().Play("CoinCollected");
            Destroy(collision.gameObject);
            Score.theScore++;
        }

        if (collision.gameObject.tag == "EndPoint")
        {
            FindObjectOfType<AudioManager>().Play("DiamondCollected");
            Destroy(collision.gameObject);
            Score.theScore += 5;
            Pause();
            
        }
    }

    public void Pause()
    {
        MenuUI.SetActive(true);
        Time.timeScale = 0f;
    }
    public void InGamePause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;

    }
   

}
