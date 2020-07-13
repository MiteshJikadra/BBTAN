using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Transform[] SpawnPosition;
    public GameObject[] Bricks;
    public GameObject[] Powerup;
    public GameObject ExtraBallPowerUp;

    public static int colNum = 6;
    public static int rowNum = 9;

    private ArrayList bricksArray;

    [SerializeField]
    public static int level;
    public int level11;
    public Transform Parent;
    public Text LevelText;

    public static GameController GC;
    private void Awake()
    {
        GC = this;
    }
    void Start()
    {
        level = 0;
        bricksArray = new ArrayList();
        for (int row = 0; row < rowNum; row++)
        {
            ArrayList tmp = new ArrayList();
            for (int col = 0; col < colNum; col++)
            {
                GameObject b = null;
                tmp.Add(b);
            }
            bricksArray.Add(tmp);
        }
        SpawnBricks();
    }

    // Update is called once per frame
    void Update()
    {
        level11 = level;
        LevelText.text = "" + GameController.level;
    }
    public void SpawnBricks()
    {
        level++;
        int extraBallPos = Random.Range(0,colNum);
        GameObject extraBall = Instantiate(ExtraBallPowerUp, SpawnPosition[extraBallPos].position,Quaternion.identity);
        extraBall.transform.parent = Parent.transform;
        SetBrick(extraBallPos, rowNum - 2, extraBall);

        for (int i = 0; i < colNum; i++)
        {
            if (GetBrick(i, rowNum - 2) == null)
            {
                int randomBrick = Random.Range(0, 6);
                if (randomBrick < 3)
                {
                    GameObject brick =Instantiate(Bricks[0], SpawnPosition[i].position, Quaternion.identity);
                    brick.transform.parent = Parent.transform;
                }
                else if (randomBrick == 4)
                {
                    GameObject brick = Instantiate(Bricks[Random.Range(1, 4)], SpawnPosition[i].position, Quaternion.identity);
                    brick.transform.parent = Parent.transform;
                }
                else if (randomBrick == 5)
                {
                    GameObject brick = Instantiate(Powerup[Random.Range(0, 3)], SpawnPosition[i].position, Quaternion.identity);
                    brick.transform.parent = Parent.transform;
                }
            }
            
        }

    }
    private GameObject GetBrick(int col, int row)
    {
        ArrayList t = bricksArray[row] as ArrayList;
        GameObject c = t[col] as GameObject;
        return c;
    }
    private void SetBrick(int col, int row, GameObject m)
    {
        ArrayList tmp = bricksArray[row] as ArrayList;
        tmp[col] = m;
    }
    public void BrickMove()
    {
        for (int row = 1; row < rowNum - 1; row++)
        {
            for (int col = 0; col < colNum; col++)
            {
                GameObject b = GetBrick(col, row);
                SetBrick(col, row - 1, b);
            }
        }
        for (int col = 0; col < colNum; col++)
        {
            SetBrick(col, rowNum - 1, null);
        }
    }
    public void ErrorBouncePowerup(int row)
    {
        while (true)
        {
            int col = Random.Range(0, colNum);
            GameObject b = GetBrick(col, row);
            if (b == null)
            {
                GameObject brick = Instantiate(Powerup[2], new Vector3(col - 3f, (float)row - 3.5f, 0), Quaternion.identity);
                SetBrick(col, row, brick);
                return;
            }
        }
    }
}
