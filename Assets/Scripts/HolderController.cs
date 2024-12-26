using UnityEngine;

public class HolderController : MonoBehaviour
{
    private bool isHolding = true;

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

        if (isHolding)
            SoundManager.OnPlayMeme?.Invoke(currentMeme.GetComponent<ObjectMerge>().GetMemeClip());

        isHolding = false;
    }

    private void HoldNextMeme()
    {
        currentMeme = Instantiate(generator.GetNextMeme(), transform);
        currentMeme.GetComponent<CircleCollider2D>().enabled = false;
        currentMeme.GetComponent<Rigidbody2D>().Sleep();

        isHolding = true;
    }

}
