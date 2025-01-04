using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using System;
using System.Collections.Generic;
using System.IO;
using System.Collections;

[System.Serializable]
public class MaxScoreList
{
    [SerializeField] private int[] maxScoreList;

    public MaxScoreList(int[] scores)
    {
        maxScoreList = scores;
    }

    public int[] GetMaxScores() { return maxScoreList; }
}

public class GameManager : MonoBehaviour
{
    [SerializeField] private int currentScore = 0;
    [SerializeField] private int[] maxScoreList = new int[4];
    [SerializeField] SoundManager soundManager;

    private string filePath;

    public static UnityEvent UpdateScorePages = new UnityEvent();

    void Awake()
    {
        filePath = Application.persistentDataPath + "/Scores.json";
        GameManager.UpdateScorePages.AddListener(LoadMaxScore);
        ObjectMerge.OnScoreChanged += AddCurrentScore;
        Instance();
        LoadMaxScore();
    }

    #region SingleTon
    private static GameManager instance;

    public void Instance()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    #endregion

    public static GameManager getInstance()
    {
        return instance;
    }

    public int GetMaxScore()
    {
        return maxScoreList[0];
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene("StartScene");
        soundManager.StopSounds();
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene("GameScene");
        soundManager.StopSounds();
    }

    public void AddCurrentScore(int score)
    {
        currentScore += score;
        ScoreUI.CurrentScoreChanged?.Invoke(currentScore);
        if (currentScore > maxScoreList[0])
            ScoreUI.MaxScoreChanged?.Invoke(currentScore);
    }

    public void SaveMaxScore()
    {
        PushMaxScore(currentScore);
        UiManager.SetMaxScoresUI?.Invoke(maxScoreList);

        MaxScoreList data = new MaxScoreList(maxScoreList);
        string jsonData = JsonUtility.ToJson(data, true);

        File.WriteAllText(filePath, jsonData);

        currentScore = 0;
    }

    public void LoadMaxScore()
    {
        if(File.Exists(filePath))
        {
            string jsonData = File.ReadAllText(filePath);

            maxScoreList = JsonUtility.FromJson<MaxScoreList>(jsonData).GetMaxScores();

            if (maxScoreList == null)
            {
                maxScoreList = new int[4] { 0, 0, 0, 0 };
            }
        }

        UiManager.SetMaxScoresUI?.Invoke(maxScoreList);
    }

    public void PushMaxScore(int score)
    {
        maxScoreList[maxScoreList.Length - 1] = score;
        Array.Sort(maxScoreList);
        Array.Reverse(maxScoreList);
    }
}
