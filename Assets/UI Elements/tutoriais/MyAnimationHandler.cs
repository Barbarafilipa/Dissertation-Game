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

    public void PlayMensagem1()
    {
        if (animator != null)
        {
            AudioManager.Instance.PlayAudio("narrator_01");
        }
        else
        {
            Debug.LogWarning("Animator component is not assigned.");
        }
    }
    public void PlayMensagem2()
    {
        if (animator != null)
        {
            AudioManager.Instance.PlayAudio("narrator_02");
        }
        else
        {
            Debug.LogWarning("Animator component is not assigned.");
        }
    }
    public void PlayMensagem3()
    {
        if (animator != null)
        {
            AudioManager.Instance.PlayAudio("narrator_03");
        }
        else
        {
            Debug.LogWarning("Animator component is not assigned.");
        }
    }
    public void PlayMensagem4()
    {
        if (animator != null)
        {
            AudioManager.Instance.PlayAudio("narrator_04");
        }
        else
        {
            Debug.LogWarning("Animator component is not assigned.");
        }
    }
}

