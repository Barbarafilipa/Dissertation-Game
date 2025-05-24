using UnityEngine;

public class MyAnimationHandler : MonoBehaviour
{
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void DisableAnimator()
    {
        animator.enabled = false;
    }

    public void DisableHand()
    {
        gameObject.SetActive(false);
    }
}

