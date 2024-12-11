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
        currentGrade.GetComponent<CircleCollider2D>().enabled = true;
        currentGrade.transform.SetParent(null);
        currentGrade.GetComponent<Rigidbody2D>().sleepMode = RigidbodySleepMode2D.NeverSleep;
        currentGrade = Instantiate(gradePrefab, transform);
    }

}
