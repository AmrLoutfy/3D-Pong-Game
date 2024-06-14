using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{   private bool stopball=true;
    public float speed;
    private Rigidbody rgb;
    private Vector3 direction;
    public float minDirection = 0.5f;
    // Start is called before the first frame update                       
    void Start()
    {
        this.rgb = GetComponent<Rigidbody>();
       
    }

    // Update is called once per frame
    void Update()
    {
        

    }
   //Moving the kinematic body method
    void FixedUpdate()
    {   if (stopball)
        {
            return;
        }

        this.rgb.MovePosition(this.rgb.position + direction * speed * Time.fixedDeltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {   //when ball hits the wall direction should change by negating z axis value 
        if (other.CompareTag("Wall")) 
        {
            direction.z = -direction.z;
        }
        //when the ball hits a racket direction should change by negating x axis value
        if (other.CompareTag("Racket"))
        {
            Vector3 newDirection = (transform.position - other.transform.position).normalized;
            newDirection.x = Mathf.Sign(newDirection.x) * Mathf.Max(Mathf.Abs(newDirection.x), this.minDirection);
            newDirection.z = Mathf.Sign(newDirection.z) * Mathf.Max(Mathf.Abs(newDirection.z), this.minDirection);
            direction = newDirection;         
        }
    }
    void RandomStartDircetion() //to make the game fair the ball starts moving in random direction each serve    
    {
        float x = Mathf.Sign(Random.Range(-1f, 1f));           
        float z = Mathf.Sign(Random.Range(-1f, 1f));
        this.direction = new Vector3(0.5f *x, 0, 0.5f* z);
    }
    public void stop()
    {
        this.stopball = true;
    }
    public void go() {   //called when start fn from game controller is called to start the game
        RandomStartDircetion(); //responsible for moving the ball in a random direction

        this.stopball = false;
}
}
