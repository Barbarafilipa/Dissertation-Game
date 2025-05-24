using UnityEngine;

public class MonsterReveal : MonoBehaviour
{
    public RectTransform flashlightMask; // UI element with transparent hole
    public GameObject furniture;         // Object to reveal
    public float revealRadius = 80f;

    private RectTransform myRect;
    private Canvas rootCanvas;

    void Start()
    {
        myRect = GetComponent<RectTransform>();
        rootCanvas = GetComponentInParent<Canvas>();
    }

    void Update()
    {
        if (furniture.activeSelf) return;

        Camera cam = rootCanvas.worldCamera; // Get the correct camera

        Vector2 flashlightScreenPos = RectTransformUtility.WorldToScreenPoint(cam, flashlightMask.position);
        Vector2 monsterScreenPos = RectTransformUtility.WorldToScreenPoint(cam, myRect.position);

        float distance = Vector2.Distance(flashlightScreenPos, monsterScreenPos);

        if (distance < revealRadius)
        {
            furniture.SetActive(true);
            gameObject.SetActive(false);
            GameManagerLanterna.Instance.MonsterRevealed();
        }
    }

}
