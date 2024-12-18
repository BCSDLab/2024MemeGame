using UnityEngine;

public class HolderController : MonoBehaviour
{
    public GameObject gradePrefab;
    public NextGradeGenerator generator;
    private GameObject currentGrade;

    private void Start()
    {
        ObjectMerge.OnIsCollidedChanged += SetToNextGrade;

        currentGrade = Instantiate(generator.GetNextGrade(), transform);

        currentGrade.GetComponent<CircleCollider2D>().enabled = false;
        currentGrade.GetComponent<Rigidbody2D>().sleepMode = RigidbodySleepMode2D.StartAsleep;
    }

    public void DropGrade()
    {
        currentGrade.GetComponent<CircleCollider2D>().enabled = true;
        currentGrade.GetComponent<Rigidbody2D>().sleepMode = RigidbodySleepMode2D.NeverSleep;

        currentGrade.transform.SetParent(null);
    }

    public void SetToNextGrade()
    {
        currentGrade = Instantiate(generator.GetNextGrade(), transform);
        currentGrade.GetComponent<CircleCollider2D>().enabled = false;
        currentGrade.GetComponent<Rigidbody2D>().sleepMode = RigidbodySleepMode2D.StartAsleep;
    }
}
