using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class SaveDataManager
{
    public static string playerName;
    public static string bestPlayer;
    public static int bestScore;

    private void Awake()
    {
        playerName = "****";
        bestPlayer = "****";
        bestScore = 0;
    }

    public void SavePlayerName()
    {
        playerName = GameObject.Find("InputField").GetComponent<InputField>().text;
    }

    public void SaveBestScore(int point)
    {
        bestScore = point;
        bestPlayer = playerName;
        SaveToJSON();
    }

    [System.Serializable]
    public class SaveData
    {
        public string savedBestPlayer;
        public int savedBestScore;
    }

    public void SaveToJSON()
    {
        SaveData data = new SaveData();

        data.savedBestPlayer = bestPlayer;
        data.savedBestScore = bestScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadFromJSON()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestPlayer = data.savedBestPlayer;
            bestScore = data.savedBestScore;
        }
    }
}
