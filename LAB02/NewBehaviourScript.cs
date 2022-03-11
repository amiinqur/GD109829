using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float initialSpeed = 100.0f;
    public float speed=100.0f;
    private Rigidbody2D rigidBall;
    public int temp=0;
    private Vector2 StartPoint;
    private void Awake()
    {
    rigidBall = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    //Abdullah and Azhar did the reset position of ball after every point scored
    void Start()
    {
        StartPoint = this.transform.position;
            rigidBall.AddForce(new Vector2(1, -1) * initialSpeed);
    }

    void OnCollisionEnter2D (Collision2D col)
    {
        if(col.gameObject.name == "paddleRight" || col.gameObject.name == "paddleLeft")
        {
            Debug.Log("aminn");
            Vector2 vel;
            vel.x = rigidBall.velocity.x;
            vel.y = (rigidBall.velocity.y / 2) + (col.collider.attachedRigidbody.velocity.y / 3);
            rigidBall.velocity=vel;
            speed+=20f;
            if(speed<130)
            {
                rigidBall.AddForce(new Vector2(vel.x, vel.y) * speed);
                Debug.Log(speed);
            }
        }
        else if(col.gameObject.name=="LeftWall")
        {
            GameManager.gameManager.RightAddPoints();
            transform.position=StartPoint;                         //abdullah and azhar

        }
        else if(col.gameObject.name=="RightWall")
        {
            GameManager.gameManager.LeftAddPoints();
            transform.position=StartPoint;                       //abdullah and azhar
        }

    }

    // Update is called once per frame
    void Update()
    {

        
    }

    void FixedUpdate()
    {
        
    }
}
