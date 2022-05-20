using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static int score;

    public int level=1;
    public static GameManager inst;

    public  TextMeshProUGUI scoreText;

    public  TextMeshProUGUI levelText;

    public MovePlayer playerMovement;

    int temp=1;

    public void IncrementScore ()
    {
        score++;
        scoreText.text = "Coins: " + score;
        // Increase the player's speed
        playerMovement.speed += playerMovement.speedIncreasePerPoint;
        if(playerMovement.speed>=20){
            if(temp<=1){
                level++;
                levelText.text="Level: "+level;
                temp++; 
            }
            else if(playerMovement.speed>=30 && temp<3){
                level++;
                levelText.text="Level: "+level;
                temp++; 
            }
            else if(playerMovement.speed>=40 && temp<4){
                level++;
                levelText.text="Level: "+level;
                temp++; 
            } 
            else if(playerMovement.speed>=50 && temp<5){
                level++;
                levelText.text="Level: "+level;
                temp++; 
            }
        }

        

    }

    private void Awake ()
    {
        inst = this;
    }

    private void Start () {

	}

	private void Update () {
	
	}
}
