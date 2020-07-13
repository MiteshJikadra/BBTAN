using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveLoadManager : MonoBehaviour
{
    public static void saveData(SaveData saveScore)
    {
        Debug.Log("Saving data");
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = new FileStream(Application.persistentDataPath + "/bb.m", FileMode.Create);

        SaveData data = saveScore;

        bf.Serialize(file, data);
        file.Close();
    }

    public static SaveData LoadData()
    {
        if (File.Exists(Application.persistentDataPath + "/bb.m"))
        {
            Debug.Log("ll");
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = new FileStream(Application.persistentDataPath + "/bb.m", FileMode.Open);

            SaveData data = bf.Deserialize(file) as SaveData;
            file.Close();
            return data;
        }
        else
        {
            Debug.LogError("File does not exists");
            return null;
        }
    }
}