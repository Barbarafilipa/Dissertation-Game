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
        GameManagerLanterna.Instance.RegisterMonster();
    }

    void Update()
    {
        if (furniture.activeSelf) return;

        // Convert both positions to screen space
        Vector2 flashlightScreenPos = RectTransformUtility.WorldToScreenPoint(null, flashlightMask.position);
        Vector2 monsterScreenPos = RectTransformUtility.WorldToScreenPoint(null, myRect.position);

        float distance = Vector2.Distance(flashlightScreenPos, monsterScreenPos);

        if (distance < revealRadius)
        {
            furniture.SetActive(true);
            gameObject.SetActive(false);
            GameManagerLanterna.Instance.MonsterRevealed();
        }
    }
}
