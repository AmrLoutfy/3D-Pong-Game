using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    private GameController gameController;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
        animator = GetComponent<Animator>();

    }

    public void StartCountdown()
    {
        animator.SetTrigger("StartCountdown");

    }
    public void StartGame()
    {
       this.gameController.StartGame(); //calls start game fn from game controller
                                        //which starts the ball movement
        
    }
}
