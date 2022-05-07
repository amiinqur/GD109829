using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightPaddle : MonoBehaviour
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
    //ABDULLAH AFAQUE 
 
    
    // void FixedUpdate()
    // {
    //     if(direction.sqrMagnitude!=0)
    //     {
    //         rigidBody.AddForce(direction * this.speed);
    //     }
            
    // }
}
