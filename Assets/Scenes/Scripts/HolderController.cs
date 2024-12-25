using UnityEngine;

public class HolderController : MonoBehaviour
{
    public NextMemeGenerator generator;
    private GameObject currentMeme;

    private void Start()
    {
        ObjectMerge.OnIsCollidedChanged += HoldNextGrade;
        HoldNextGrade();
    }

    public void DropGrade()
    {
        currentMeme.GetComponent<CircleCollider2D>().enabled = true;
        currentMeme.GetComponent<Rigidbody2D>().WakeUp();
        currentMeme.transform.SetParent(null);
    }

    private void HoldNextGrade()
    {
        currentMeme = Instantiate(generator.GetNextGrade(), transform);
        currentMeme.GetComponent<CircleCollider2D>().enabled = false;
        currentMeme.GetComponent<Rigidbody2D>().Sleep();
    }

}
