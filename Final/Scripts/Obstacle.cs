using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    MovePlayer playerMovement;

	private void Start () {
        playerMovement = GameObject.FindObjectOfType<MovePlayer>();
	}

    private void OnCollisionEnter (Collision collision)
    {
        if (collision.gameObject.name == "Runner" || collision.gameObject.name == "Ch06_nonPBR@Running") {
            // Kill the player
            playerMovement.Die();
        }
    }

    private void Update () {
	
	}
}
