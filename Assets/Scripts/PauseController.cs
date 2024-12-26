using UnityEngine;

public class PauseController : MonoBehaviour
{
    GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    public void RestartGame()
    {
        gameManager.LoadGameScene();
    }

    public void ReturnToTitle()
    {
        gameManager.LoadStartScene();
    }

}
