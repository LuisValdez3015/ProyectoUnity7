using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class LoadData : MonoBehaviour
{

    private const string fileName = "save.txt";

    public SavedData LoadGame()
    {
        SavedData data = new SavedData();

        data.levelIndex = new bool[3];

        if (File.Exists(Application.persistentDataPath + "/" + fileName))
        {
             data = JsonUtility.FromJson<SavedData>(File.ReadAllText(Application.persistentDataPath + "/" + fileName));
        }

        return data;
        //string json = ReadFile();
        //Debug.Log("Saved Json:\n" + json);
        //SavedData savedData = JsonUtility.FromJson<SavedData>(json);
    }

    //private string ReadFile()
    //{
    //    string path = Path.Combine(Application.persistentDataPath, fileName);

    //    if (File.Exists(path))
    //    {
    //        string data = File.ReadAllText(path);
    //        return data;
    //    }
    //    else
    //    {
    //        Debug.LogWarning("No existe el archivo: " + fileName);
    //        return "";
    //    }
    //}

}
