using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrickManager : MonoBehaviour
{
    public Gradient gradient;
    private SpriteRenderer brickRenderer;
    public int brickHelth;
    private Text brickHelthText;
    public GameObject brickDistroyPartical;
    public static BrickManager BM;
    private void Awake()
    {
        BM = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        brickHelth = GameController.level;
        brickRenderer = GetComponent<SpriteRenderer>();
        brickRenderer.color = gradient.Evaluate(1 / (float)brickHelth + 0.5f);
        brickHelth = GameController.level;
        brickHelthText = GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        brickHelthText.text = "" + brickHelth;
        if (brickHelth < 1)
        {
            Destroy(this.gameObject);
            Instantiate(brickDistroyPartical,transform.position,Quaternion.identity);
        }
    }
    private void Damage(int damage)
    {
        brickHelth -= damage;
        brickRenderer.color = gradient.Evaluate(1 / (float)brickHelth + 0.5f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Ball")
        {
            Damage(1);
            SoundManager.Sm.brickTouchSound();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="PowerUp")
        {
            Damage(1);
        }
    }
   
}
