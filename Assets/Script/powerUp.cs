using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PowerUpBall
{
    Horizontal,
    vartical,
    AddnewBall
}
public class powerUp : MonoBehaviour
{
    public PowerUpBall type;
    private bool isTrigger = false;
    public GameObject hit;
    //public static powerUp PU;
    private BallManager1 ballm;
    //private void Awake()
    //{
    //    PU = this;
    //}

    // Start is called before the first frame update
    void Start()
    {
        ballm = FindObjectOfType<BallManager1>();
    }

    // Update is called once per frame
    void Update()
    {
        if (BallManager1.BM1.currentBallState==ballState.ENDGAME)
        {
            Debug.Log(BallManager1.BM1.currentBallState == ballState.ENDGAME);
            //Debug.Log("check");
            if (isTrigger)
            { 
                Destroy(this.gameObject);
            }
            
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Ball" && (BallManager1.BM1.currentBallState==ballState.FIRE || BallManager1.BM1.currentBallState==ballState.ENDSHOT))
        {
            isTrigger = true;
            switch (type)
            {
                case PowerUpBall.Horizontal:
                    hit.GetComponent<LineRenderer>().SetPosition(0,new Vector3(-4,transform.position.y,0));
                    hit.GetComponent<LineRenderer>().SetPosition(1,new Vector3(4,transform.position.y,0));
                    hit.SetActive(true);
                    Invoke("EndHit",0.05f);

                    break;
                case PowerUpBall.vartical:
                    hit.GetComponent<LineRenderer>().SetPosition(0, new Vector3(transform.position.x,-6, 0));
                    hit.GetComponent<LineRenderer>().SetPosition(1, new Vector3(transform.position.x, 6, 0));
                    hit.SetActive(true);
                    Invoke("EndHit", 0.05f);
                    break;
                case PowerUpBall.AddnewBall:
                    if (collision.gameObject.transform.position.y > transform.position.y)
                    {
                        if (Mathf.Abs(collision.GetComponent<Rigidbody2D>().velocity.y) < 0.1 || Mathf.Abs(collision.GetComponent<Rigidbody2D>().velocity.x) < 0.1 )
                        {
                            int r = Random.Range(-1, 2);
                            Vector2 tmp = new Vector2(r * Mathf.Tan(Mathf.Deg2Rad * 45), 1).normalized *10f;
                            collision.gameObject.GetComponent<Rigidbody2D>().velocity = tmp;
                        }
                        else
                        {
                            Vector2 tmp = collision.GetComponent<Rigidbody2D>().velocity + new Vector2(0.2f, 0f);
                            collision.gameObject.GetComponent<Rigidbody2D>().velocity = -tmp;
                        }
                        
                    }
                    else
                    {
                        int t = Random.Range(-1, 2);
                        Vector2 tmp = new Vector2(t * Mathf.Tan(Mathf.Deg2Rad * 45), 1).normalized * 10f;
                        collision.gameObject.GetComponent<Rigidbody2D>().velocity = tmp;
                    }
                    hit.SetActive(true);
                    GetComponent<SpriteRenderer>().enabled = false;
                    Invoke("EndHit",0.02f);
                    break;
                default:
                    break;
            }
        }
    }
    private void EndHit()
    {
        hit.SetActive(false);
        GetComponent<SpriteRenderer>().enabled = true;
    }    
}
