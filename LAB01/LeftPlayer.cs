using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftPlayer : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private Vector2 direction;
    public float speed = 10.0f;
    // Update is called once per frame
    //SYED MUHAMMAD AZHAR
    void Update()
    {
        var vel = rigidBody.velocity;
                if (Input.GetKey(KeyCode.S))
                {
                    direction = Vector2.down;
                    vel.y=-speed;
                }
                else if (Input.GetKey(KeyCode.W))
                {
                    direction = Vector2.up;
                    vel.y=speed;
                }
                    
                else
                {
                    direction = Vector2.zero;
                    vel.y=0;
                }
                rigidBody.velocity=vel;
                    
    }
    
    // void FixedUpdate()
    // {
    //     if(direction.sqrMagnitude!=0)
    //     {
    //         rigidBody.AddForce(direction * this.speed);
    //     }
            
    // }
}
