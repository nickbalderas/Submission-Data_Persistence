using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public List<ScoreData> scores = new List<ScoreData>();
    public ScoreData HighScore;
    public ScoreData CurrentScore;

    private void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadScore();
    }
    
    public void SaveScore()
    {
        ScoreData data = new ScoreData();
        data.playerName = CurrentScore.playerName;
        data.score = CurrentScore.score;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/scoredata.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/scoredata.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            ScoreData data = JsonUtility.FromJson<ScoreData>(json);
            HighScore.playerName = data.playerName;
            HighScore.score = data.score;
        }
    }
}

[Serializable]
public class ScoreData
{
    public string playerName;
    public int score;
}