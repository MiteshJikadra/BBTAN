using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreManager : MonoBehaviour
{
    public Text topscore;
    public int highScore1 = 0;
    private void Awake()
    {
       
    }
    private void Start()
    {
        LoadData();
    }
    private void Update()
    {
        SaveData a = new SaveData(highScore1);
        SaveLoadManager.saveData(a);
        AddScore();
        //highScore1 = GameController.GC.level11;

    }
    public void AddScore()
    {

        //topscore.text = GameController.GC.level11.ToString();
        if (GameController.GC.level11 > highScore1)
        {
            highScore1 = GameController.GC.level11;
            topscore.text = highScore1.ToString();
            
            SaveData a = new SaveData(highScore1);
            SaveLoadManager.saveData(a);
        }

    }
    public void LoadData()
    {
        SaveData data = SaveLoadManager.LoadData();
        highScore1 = data.TopScore;

        topscore.text = highScore1.ToString();
    }
}