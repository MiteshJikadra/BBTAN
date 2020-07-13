using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class gameobjectactivdiactive : MonoBehaviour
{
    public GameObject gamecontroller;
    public GameObject ballmanager;
    public GameObject canvas;
    public GameObject down;
    public GameObject top;
    public GameObject datasore;
    public static gameobjectactivdiactive GAD;
    private void Awake()
    {
        GAD = this;
    }
   
    public void active()
    {
        gamecontroller.SetActive(true);
        ballmanager.SetActive(true);
        canvas.SetActive(true);
        down.SetActive(true);
        datasore.SetActive(true);
        top.SetActive(true);
    }
    public void dactive()
    {
        gamecontroller.SetActive(false);
        ballmanager.SetActive(false);
        canvas.SetActive(false);
        down.SetActive(false);
        datasore.SetActive(false);
        top.SetActive(false);
    }
   
}
