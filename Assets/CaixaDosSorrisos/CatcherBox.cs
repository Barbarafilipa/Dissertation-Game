using UnityEngine;
using System.Collections.Generic;

public class CatcherBox : MonoBehaviour
{
    private RectTransform catcherRect;
    private Animator animator;

    private void Awake()
    {
        catcherRect = GetComponent<RectTransform>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        CheckForCaughtEmojis();
    }

    void CheckForCaughtEmojis()
    {
        // Find all emojis in scene (optimize later with pooling)
        GameObject[] emojis = GameObject.FindGameObjectsWithTag("Emoji");

        foreach (GameObject emoji in emojis)
        {
            RectTransform emojiRect = emoji.GetComponent<RectTransform>();
            if (IsOverlapping(emojiRect, catcherRect))
            {
                // Emoji caught
                Destroy(emoji); // or disable if using pooling
                Debug.Log("Caught an emoji!");

                // TODO: Add score or play animation
                if (emoji.GetComponent<EmojiFall>().emojiType == EmojiFall.EmojiType.Happy)
                {
                    // Add score for happy emoji
                    ScoreManager.Instance.AddScore(1); // Assuming you have a ScoreManager

                    // Play happy animation in Animator
                    animator.Play("caught_happy");
                }
                else
                {
                    // Subtract score for sad emoji
                    ScoreManager.Instance.AddScore(-1); // Assuming you have a ScoreManager

                    // Play sad animation in Animator
                    animator.Play("caught_sad");
                }
            }
        }
    }

    bool IsOverlapping(RectTransform a, RectTransform b)
    {
        Vector3[] cornersA = new Vector3[4];
        Vector3[] cornersB = new Vector3[4];
        a.GetWorldCorners(cornersA);
        b.GetWorldCorners(cornersB);

        Rect rectA = new Rect(cornersA[0], cornersA[2] - cornersA[0]);
        Rect rectB = new Rect(cornersB[0], cornersB[2] - cornersB[0]);

        return rectA.Overlaps(rectB);
    }
}
