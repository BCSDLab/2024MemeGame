using System.Collections;
using UnityEngine;

public class MemeAnimator : MonoBehaviour
{
    private Animator anim;
    private bool isAnimPlayed = false;
    IEnumerator currentCoroutine;

    [SerializeField] private float animationPlayTime;


    private void OnDestroy()
    {
        if(currentCoroutine != null)
        {
            StopCoroutine(currentCoroutine);
        }
    }

    public void playAnimation()
    {
        if (!isAnimPlayed)
        {
            anim = GetComponent<Animator>();
            anim.SetBool("isPlay", true);
            isAnimPlayed = true;
            currentCoroutine = AnimatorCoroutine();
            StartCoroutine(currentCoroutine);
        }
    }

    IEnumerator AnimatorCoroutine()
    {
        yield return new WaitForSeconds(animationPlayTime);
        anim?.SetBool("isPlay", false);
    }

}
