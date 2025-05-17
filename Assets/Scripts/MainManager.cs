using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    static public MainManager Instance;

    public BestScore Highscore { get; private set; }
    public string CurrentPlayerName;
    private string bestScoreFilePath;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Debug.Log("Awake MainManager");

        Instance = this;
        DontDestroyOnLoad(gameObject);

        bestScoreFilePath = Application.persistentDataPath + "/best_score.json";

        LoadBestScore();
    }

    [Serializable]
    public struct BestScore
    {
        public string playerName;
        public int points;
    }

    public string GetLastBestScoreText()
    {
        string playerName = Highscore.playerName;
        int score = Highscore.points;
        return $"Best Score: {playerName}: {score}";
    }

    public void UpdateBestScore(int points)
    {
        BestScore newHighscore = new BestScore();
        newHighscore.points = points;
        newHighscore.playerName = CurrentPlayerName;
        Highscore = newHighscore;
        SaveBestScore();
    }

    void SaveBestScore()
    {
        string json = JsonUtility.ToJson(Highscore);
        File.WriteAllText(bestScoreFilePath, json);
    }

    void LoadBestScore()
    {
        if (!File.Exists(bestScoreFilePath))
            return;

        string json = File.ReadAllText(bestScoreFilePath);
        Highscore = JsonUtility.FromJson<BestScore>(json);
    }
}
