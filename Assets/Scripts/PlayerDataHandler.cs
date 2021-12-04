using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class PlayerDataHandler : MonoBehaviour
{
    public static PlayerDataHandler Instance;

    public int bestScore;
    public string bestPlayer;

    
    private void Awake()
    {
                
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(this);
        Instance = this;

        LoadHighScore();
    }

   

    public void ValidateHighScore(int points)
    {
        if (points > bestScore)
        {
            bestScore = points;
            bestPlayer = DataManager.Instance.playerName;
        }
    }

    [System.Serializable]
    class SaveData
    {
        public int dataBestScore;
        public string dataBestPlayer;
    }

    public void SaveHighScore()
    {
        SaveData data = new SaveData();
        data.dataBestScore = bestScore;
        data.dataBestPlayer = bestPlayer;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        Debug.Log(Application.persistentDataPath);
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
          
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestScore = data.dataBestScore;
            bestPlayer = data.dataBestPlayer;
        }
    }

    public void DeleteFile()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            File.Delete(Application.persistentDataPath + "/savefile.json");
        }
    }
}
