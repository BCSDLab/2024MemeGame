using UnityEngine;

public class GameOverBoundary : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        ObjectMerge obm = collision.gameObject.GetComponent<ObjectMerge>();

        if(obm != null && obm.isCollided)
        {
            Debug.Log("게임 종료!");
        }
    }
}
