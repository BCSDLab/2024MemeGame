using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    #region SingleTon
    private static GameObject instance;

    public GameObject Instance()
    {
        if(instance == null)
            instance = this.gameObject;

        DontDestroyOnLoad(instance);
        return instance;
    }
    #endregion

    [SerializeField ]private int currentScore = 0;
    private int maxScore = 0;

    void Awake()
    {
        ObjectMerge.OnScoreChanged += AddCurrentScore;
        Instance();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.B))
            SceneManager.LoadScene("StartScene");
    }

    public void GameSceneLoad()
    {
        SceneManager.LoadScene("TestScene");
    }

    public void AddCurrentScore(int score)
    {
        currentScore += score;
        ScoreUI.CurrentScoreChanged?.Invoke(currentScore);
    }
}
