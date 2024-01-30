using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }
    public HighScoreData BestScore { get; private set; }

    private readonly string _scoreFileName = "BestScore.json";

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        LoadHighScore();
    }

    void LoadHighScore()
    {
        string filePath = Path.Combine(Application.persistentDataPath, _scoreFileName);

        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            BestScore = JsonUtility.FromJson<HighScoreData>(json);
        }
    }

    public void SaveScore(string playerName, int score)
    {
        var persistScore = false;

        if (BestScore == null)
        {
            BestScore = new HighScoreData(playerName, score);
            persistScore = true;
        }
        else
        {
            if (score > BestScore.score)
            {
                BestScore.name = playerName;
                BestScore.score = score;
                persistScore = true;
            }
        }

        if (persistScore)
        {
            string json = JsonUtility.ToJson(BestScore);
            string filePath = Path.Combine(Application.persistentDataPath, _scoreFileName);
            System.IO.File.WriteAllText(filePath, json);
        }
    }
}
