using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketController : MonoBehaviour
{
    public float speed;
    public KeyCode up;
    public KeyCode down;
    private Rigidbody rb;
    public bool isPlayer = true;
    private Transform ball;
    public float offset = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ball = GameObject.FindGameObjectWithTag("Ball").transform;
    }

    // Update is called once per frame
    void Update()
    { 
        if (this.isPlayer)
        {
            PlayerSelected();
        }
        else
        {
            AIselected();
        }
       
    }
    public void PlayerSelected()
    {
        bool pressedUp = Input.GetKey(this.up);
        bool pressedDown = Input.GetKey(this.down);
        if (pressedUp)
        {
            rb.velocity = Vector3.forward * speed;

        }
        if (pressedDown)
        {
            rb.velocity = Vector3.back * speed;

        }
        if (!pressedUp && !pressedDown)
        {
            rb.velocity = Vector3.zero;

        }
    }


    public void AIselected()                                       //The algorithm first checks if the ball is ahead of the AI's position, with a value of offset.
                                                                   //If it is, the AI moves forward towards the ball at a constant speed by setting its velocity to Vector3.forward * speed.
                                                                   //If the ball is behind the AI's position, the AI moves backward towards the ball at the same speed by setting its velocity to Vector3.back * speed.
                                                                   //If the ball is within the offset range, the AI stops moving by setting its velocity to Vector3.zero.
    {
        if(ball.position.z > transform.position.z +offset)
        {
            rb.velocity = Vector3.forward * speed;
        }
        else if (ball.position.z < transform.position.z -offset)
        {
            rb.velocity = Vector3.back * speed;
        }
        else
        {
            rb.velocity = Vector3.zero; 
        }
    }
}
