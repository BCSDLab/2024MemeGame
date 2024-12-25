using UnityEngine;

public class HolderController : MonoBehaviour
{
    public NextMemeGenerator generator;
    private GameObject currentMeme;

    private void Start()
    {
        ObjectMerge.OnIsCollidedChanged += HoldNextMeme;
        HoldNextMeme();
    }

    private void OnDestroy()
    {
        ObjectMerge.OnIsCollidedChanged -= HoldNextMeme;
    }

    public void DropGrade()
    {
        currentMeme.GetComponent<CircleCollider2D>().enabled = true;
        currentMeme.GetComponent<Rigidbody2D>().WakeUp();
        currentMeme.transform.SetParent(null);
    }

    private void HoldNextMeme()
    {
        currentMeme = Instantiate(generator.GetNextMeme(), transform);
        currentMeme.GetComponent<CircleCollider2D>().enabled = false;
        currentMeme.GetComponent<Rigidbody2D>().Sleep();
    }

}
