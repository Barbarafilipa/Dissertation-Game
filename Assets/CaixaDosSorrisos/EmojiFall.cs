using UnityEngine;

public class EmojiFall : MonoBehaviour
{
    public enum EmojiType { Happy, Sad }
    public EmojiType emojiType;
    public float fallSpeed = 200f; // pixels per second
    private RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        rectTransform.anchoredPosition -= new Vector2(0, fallSpeed * Time.deltaTime);
    }
}
