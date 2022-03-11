using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//AMIN M. QURAISHI WORKED ON DIPLAYING THE SCORES AND THE WINNING MESSAGE

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager = null;
    public Text leftScore;
    public Text rightScore;

    public Text winScore;

    int left=0;
    int right=0;
    private void Awake() {
            if(gameManager==null){
                gameManager=this;
            }
    }
    // Start is called before the first frame update
    void Start()
    {
        leftScore.text="Left Player "+left.ToString() + " points";
        rightScore.text="Right Player "+right.ToString() + " points";
        
    }

    // Update is called once per frame
    public void LeftAddPoints()
    {
        left++;
        leftScore.text="Left Player "+left.ToString() + " points";
    }
    public void RightAddPoints()
    {
        right++;
        rightScore.text="Right Player "+right.ToString() + " points";
    }
    void Update() {
        if(left==10){
            winScore.text="Left Player Won!";
            left=0;
            right=0;
            Time.timeScale=0;
        }
        else if(right==10){
            winScore.text="Right Player Won!";
            right=0;
            left=0;
            Time.timeScale=0;
        }
    }
}
