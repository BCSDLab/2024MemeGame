using UnityEngine;

public class HolderController : MonoBehaviour
{
    [SerializeField] public GameObject gradePrefab;
    private GameObject currentGrade;

    private void Start()
    {
        currentGrade = Instantiate(gradePrefab, transform);
        currentGrade.GetComponent<CircleCollider2D>().enabled = false;
        currentGrade.GetComponent<Rigidbody2D>().sleepMode = RigidbodySleepMode2D.StartAsleep;
    }

    public void DropGrade()
    {
        Debug.Log(currentGrade);

        currentGrade.GetComponent<CircleCollider2D>().enabled = true;
        currentGrade.GetComponent<Rigidbody2D>().sleepMode = RigidbodySleepMode2D.NeverSleep;

        currentGrade.transform.SetParent(null);
    }

    public void GetNextGrade()
    {
        currentGrade = Instantiate(gradePrefab, transform);
        currentGrade.GetComponent<CircleCollider2D>().enabled = false;
        currentGrade.GetComponent<Rigidbody2D>().sleepMode = RigidbodySleepMode2D.StartAsleep;
    }
}
