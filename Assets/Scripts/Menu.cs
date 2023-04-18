using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Menu : MonoBehaviour
{
    public static Menu Instance;
    public string playerName;
    public int highScore;
    public int playerScore;
//     public int playerStartingScore = 0;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    class CurrentData
    {
        public string playerName;
        public int playerScore;
    }

    public void SavePlayerScore(string player, int highscore)
    {
        CurrentData currentData = new CurrentData();
        currentData.playerName = player;
        currentData.playerScore = highscore;

        string json = JsonUtility.ToJson(currentData);

        File.WriteAllText(Application.persistentDataPath + "/highscore.json", json);
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/highscore.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            CurrentData highScoreData = JsonUtility.FromJson<CurrentData>(json);
            highScore = highScoreData.playerScore;
            playerName = highScoreData.playerName;
            // return highScore;
        }
        else
        {
            playerName = " ";
            highScore = 0;
        }
    }
}
