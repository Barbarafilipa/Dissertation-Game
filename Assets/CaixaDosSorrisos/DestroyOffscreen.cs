using UnityEngine;

public class EmojiAutoDestroy : MonoBehaviour
{
    private RectTransform rectTransform;
    private RectTransform parentRect;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        parentRect = transform.parent.GetComponent<RectTransform>();
    }

    void Update()
    {
        if (!IsVisibleInParent())
        {
            Destroy(gameObject);
        }
    }

    bool IsVisibleInParent()
    {
        Vector3[] emojiCorners = new Vector3[4];
        Vector3[] parentCorners = new Vector3[4];

        rectTransform.GetWorldCorners(emojiCorners);
        parentRect.GetWorldCorners(parentCorners);

        float emojiBottom = emojiCorners[0].y;
        float parentBottom = parentCorners[0].y;

        return emojiBottom > parentBottom; // still visible above bottom
    }
}
