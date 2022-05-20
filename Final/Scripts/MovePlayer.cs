using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MovePlayer : MonoBehaviour
{
    // Start is called before the first frame update
    bool alive = true;

    public float speed = 5;
    public Rigidbody rb;

    public Animator myAnim;

    float horizontalInput;
    public float horizontalMultiplier = 1.5f;

    public float speedIncreasePerPoint = 0.1f;

    public float jump=400f;
    public LayerMask groundMask;

    public AudioSource aud;

    public AudioSource aud1;

    //public  TextMeshProUGUI hscoreText;

    //private int highscore=0;

    private void FixedUpdate ()
    {
        if (!alive) return;

        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;
        rb.MovePosition(rb.position + forwardMove+horizontalMove);
    }

    void Start()
    {
        //hscoreText.text="HighScore: "+PlayerPrefs.GetInt("HighScore",0).ToString();
    }

    private void Update () {
        horizontalInput = Input.GetAxis("Horizontal");

        if(Input.GetKeyDown(KeyCode.Space)){
            myAnim.Play("Jump");
            aud1.Stop();
            Jump();
            aud1.Play();
        }

        if (transform.position.y < -5 || transform.position.x >= 6 || transform.position.x <= -6) {
            Die();
        }
	}

    public void Die ()
    {
        alive = false;
        myAnim.Play("Flying Back Death");
        aud.Stop();
        aud1.Stop();
        // if(GameManager.score>highscore){
        //     highscore=GameManager.score;
        //     PlayerPrefs.SetInt("HighScore: ",highscore);
        // }
        // else{
        //     PlayerPrefs.SetInt("HighScore: ",highscore);
        // }
        // hscoreText.text="High Score: "+highscore;
        // Restart the game
         Invoke("Restart", 2);
    }

    void Restart ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
    }

    void Jump()
    {
        float height = GetComponent<Collider>().bounds.size.y;
        bool isGrounded=Physics.Raycast(transform.position,Vector3.down,(height/2)+0.1f,groundMask);
        rb.AddForce(Vector3.up*jump);

    }
}
