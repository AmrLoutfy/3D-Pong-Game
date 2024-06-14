using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{   private int scoreleft=0; private int scoreright=0; // goals scored each side
    private int scoreLimit = 5;
    public GameObject ball;  //ball referance
    public Text scoretextL;
    public Text scoretextR;
    public Countdown countdown;

    private bool start = false;
   
    private BallControl ballcontrol; //ball  Script referance 
    private Vector3 startingpoint;
    
    // Start is called before the first frame update
    void Start()
    {
        this.ballcontrol = this.ball.GetComponent<BallControl>();
        this.startingpoint =this.ball.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.start) //start is false so the game wont begin and the code will not be executed 
        {
            return;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            this.start = true;   // we set the value of start to true if the player hits
            this.countdown.StartCountdown();                    // the key space in order to continue the code execution and start the game

        }
    }
   private void UpdateUI() //responsible for updating the score
    {
        this.scoretextL.text = this.scoreleft.ToString(); //Converting the scoreleft  to string 
        this.scoretextR.text = this.scoreright.ToString();
    }
    public void StartGame()
    {
        this.ballcontrol.go();

    }


    public void ScoreGoalLeft()
    {
        Debug.Log("ScoreGoalLeft");
        if (this.scoreright < this.scoreLimit)
        {
            this.scoreright += 1;
        }
        UpdateUI();
        if (this.scoreleft >= this.scoreLimit || this.scoreright >= this.scoreLimit)
        {
            EndGame();
        }
        else
        {
            ResetBall();
        }

    }

    public void ScoreGoalRight()
    {
        Debug.Log("ScoreGoalRight");
        if (this.scoreleft < this.scoreLimit)
        {
            this.scoreleft += 1;
        }
        UpdateUI();
        if (this.scoreleft >= this.scoreLimit || this.scoreright >= this.scoreLimit)
        {
            EndGame();
        }
        else
        {
            ResetBall();
        }

    }

    private void ResetBall()
    {
        this.ballcontrol.stop();
        this.ball.transform.position=this.startingpoint;
        this.countdown.StartCountdown();

    }
    private void EndGame()
    {
        // End the game
        Debug.Log("Game over!");
    }
}
