using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class DataManager : MonoBehaviour
{

    public static DataManager Instance;

    
    public GameObject nameInput;
    public Text bestScoreT;
    
    public string playerName;
    public int bestScoreValue;
    

    private void Awake()
    {
        
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            LoadHighScore();
            bestScoreT.text = "Best Score " + bestScoreValue + " by " + playerName;
        }
        else if (Instance != this)
        {
            Destroy(Instance.gameObject);
            Instance = this;
            DontDestroyOnLoad(gameObject);

            bestScoreT.text = "Best Score " + PlayerDataHandler.Instance.bestScore + " by " + PlayerDataHandler.Instance.bestPlayer;
        }
    }

    public void GetName()
    {
        playerName = nameInput.GetComponent<Text>().text;
    }

    [System.Serializable]
    class SaveData
    {
        public int dataBestScore;
        public string dataBestPlayer;
    }


    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestScoreValue = data.dataBestScore;
            playerName = data.dataBestPlayer;
        }
    }

}
