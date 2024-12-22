using UnityEngine;

public class HolderController : MonoBehaviour
{
    public NextGradeGenerator generator;
    private GameObject currentGrade;

    private void Start()
    {
        ObjectMerge.OnIsCollidedChanged += HoldNextGrade;
        HoldNextGrade();
    }

    public void DropGrade()
    {
        currentGrade.GetComponent<CircleCollider2D>().enabled = true;
        currentGrade.GetComponent<Rigidbody2D>().WakeUp();
        currentGrade.transform.SetParent(null);
    }

    private void HoldNextGrade()
    {
        currentGrade = Instantiate(generator.GetNextGrade(), transform);
        currentGrade.GetComponent<CircleCollider2D>().enabled = false;
        currentGrade.GetComponent<Rigidbody2D>().Sleep();
    }

}
