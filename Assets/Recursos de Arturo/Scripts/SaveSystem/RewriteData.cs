using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class RewriteData : MonoBehaviour
{
    private const string fileName = "save.txt";

    private void SaveData(SavedData data)
    {
        string json = JsonUtility.ToJson(data, true);
        WriteData(json);
    }

    private void WriteData(string json)
    {
        string path = Path.Combine(Application.persistentDataPath, fileName);
        File.WriteAllText(path, json);
    }

    public void SaveLevel(int index)
    {
        SavedData data = FindObjectOfType<LoadData>().LoadGame();

        data.levelIndex[index] = true;

        SaveData(data);
    }
}
