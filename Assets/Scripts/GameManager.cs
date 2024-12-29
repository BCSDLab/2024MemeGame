using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using System.Collections.Generic;
using System.IO;
using System.Collections;

[System.Serializable]
public class MaxScoreList
{
    [SerializeField]
    private List<int> maxScores;

    public MaxScoreList(List<int> scores)
    {
        maxScores = scores;
    }

    public List<int> GetMaxScores() { return maxScores; }
}

public class GameManager : MonoBehaviour
{
    [SerializeField] private int currentScore = 0;
    [SerializeField] private List<int> maxScoreList;
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

    void Update()
    {
        if (Input.GetKey(KeyCode.B))
            SceneManager.LoadScene("StartScene");

        if (Input.GetKey(KeyCode.S))
            SaveMaxScore();
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene("StartScene");
        soundManager.StopSounds();
    }

    public void LoadGameScene()
    {
        StartCoroutine(LoadGameSceneAsync());
        soundManager.StopSounds();
    }

    private IEnumerator LoadGameSceneAsync()
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("GameScene");

        while (!asyncOperation.isDone)
        {
            yield return null;
        }

        ScoreUI.MaxScoreChanged?.Invoke(maxScoreList[0]);
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

        //현재 점수 초기화
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
                maxScoreList = new List<int> { 0, 0, 0 };
            }
        }

        UiManager.SetMaxScoresUI?.Invoke(maxScoreList);
    }

    public void PushMaxScore(int score)
    {
        maxScoreList.Add(score);
        maxScoreList.Sort();
        maxScoreList.Reverse();
        maxScoreList.RemoveAt(maxScoreList.Count - 1);
    }
}
