using UnityEngine;

public class HolderController : MonoBehaviour
{
    [SerializeField] public GameObject gradePrefab;
    private GameObject currentGrade;

    private void Awake()
    {
    }

    private void Start()
    {
        currentGrade = Instantiate(gradePrefab, transform);
    }

    public void DropGrade()
    {
        Debug.Log(currentGrade);
        AwakeBlock();
        currentGrade.transform.SetParent(null);
        currentGrade = Instantiate(gradePrefab, transform);
        SleepBlock();
    }

    private void AwakeBlock()
    {
        currentGrade.GetComponent<CircleCollider2D>().enabled = true;
        currentGrade.GetComponent<Rigidbody2D>().sleepMode = RigidbodySleepMode2D.NeverSleep;
    }

    private void SleepBlock()
    {
        currentGrade.GetComponent<CircleCollider2D>().enabled = false;
        currentGrade.GetComponent<Rigidbody2D>().sleepMode = RigidbodySleepMode2D.StartAsleep;
    }

}
