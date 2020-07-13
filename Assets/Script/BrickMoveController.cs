using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickMoveController : MonoBehaviour
{
    public static BrickMoveController BMC;
    public Vector3 startpos;
    public Vector3 endpos;
    public float i=3,j=3;
    //[SerializeField] [Range(0f, 4f)] float lerptime;
    //[SerializeField] Vector3[] myposition;
    //int posIndex = 0;
    //int lenght;
    //float t = 0f;
    //private bool hasMoved;
    // Start is called before the first frame update
    private void Awake()
    {
        BMC = this;
    }
    void Start()
    {
        //hasMoved = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BricksMove()
    {
        //i = j;
        i--;
        j--;
        //float d = Vector3.Distance(transform.position,new Vector3(transform.position.x, transform.position.y - 1, transform.position.z));
        StartCoroutine(LerpRouti(new Vector3(0,i,0),new Vector3(0,j,0),0.4f));
        //startpos = new Vector3(transform.position.x,transform.position.y ,transform.position.z);
        //endpos = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
        //transform.position = Vector3.Lerp(startpos, endpos, d);
        transform.position = new Vector2(transform.position.x, transform.position.y - 1);
        GameController.GC.BrickMove();
        GameController.GC.SpawnBricks();
        SoundManager.Sm.levelIncreseSound();

    }
    //private IEnumerator LerpRoutine(Vector3 target,Vector3 start ,float duration)
    //{
    //    //Vector3 start = transform.position;
    //    float elapsedTime = 0.0f;

    //    while (transform.position != target)
    //    {
    //        elapsedTime += Time.deltaTime;
    //        transform.position = Vector3.Lerp(start, target, elapsedTime / duration);
    //        yield return null;
    //    }
    //}
    public IEnumerator LerpRouti(Vector3 target, Vector3 start, float duration)
    {
        //Vector3 start = transform.position;
        float elapsedTime = 0.0f;

        while (transform.position != target)
        {
            elapsedTime += Time.deltaTime;
            transform.position = Vector3.Lerp(start, target, elapsedTime / duration);
            yield return null;
        }
    }
    //public void brickm()
    //{
    //    StartCoroutine(LerpRoutine(new Vector3(transform.position.x, transform.position.y - 1, transform.position.z), transform.position, 0.7f));
    //}

}
