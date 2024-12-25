using System;
using UnityEngine;

public class GameOverBoundary : MonoBehaviour
{
    public static event Action onGameOver;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        ObjectMerge obm = collision.gameObject.GetComponent<ObjectMerge>();

        if(obm != null && obm.isCollided)
        {
            onGameOver?.Invoke();
        }
    }
}
