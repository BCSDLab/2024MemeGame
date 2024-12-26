using System;
using UnityEngine;
using UnityEngine.Events;

public class GameOverBoundary : MonoBehaviour
{
    public static UnityEvent OnGameOver = new UnityEvent();

    [SerializeField] private GameManager gameManager;

    public void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        ObjectMerge obm = collision.gameObject.GetComponent<ObjectMerge>();

        if(obm != null && obm.isCollided)
        {
            gameManager.SaveMaxScore();
            OnGameOver?.Invoke();
        }
    }
}
