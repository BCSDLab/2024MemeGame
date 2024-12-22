using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    private int currentScore = 0;
    private int maxScore = 0;

    void Awake()
    {
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
}
