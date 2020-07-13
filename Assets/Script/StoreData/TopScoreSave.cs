using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class SaveData
{
    public int TopScore;
    public SaveData(int scoreH)
    {
        TopScore = scoreH;
        //BGIndex = index;

    }
}