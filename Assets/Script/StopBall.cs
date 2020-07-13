using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopBall : MonoBehaviour
{
    //private BallController ballControl;
    private int counter;

    private bool firstball;
   
    // Start is called before the first frame update
    void Start()
    {
        firstball = true;
        //ballControl = FindObjectOfType<BallController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (counter == BallManager1.BM1.numOfBalls)
        {
            firstball = true;
            counter = 0;
            BallManager1.BM1.currentBallState = ballState.NEXTLEVEL;
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {

            if (firstball)
            {
                firstball = false;
                collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                Vector3 point = collision.transform.position;
                point.y = -4.33f;
                BallManager1.BM1.transform.position = point;
                Destroy(collision.gameObject);
            }
            else
            {
                Destroy(collision.gameObject);
            }
            counter++;
        }
        
    }
    
}
