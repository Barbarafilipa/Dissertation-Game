using UnityEngine;
using UnityEngine.UI;

public class MonsterReveal : MonoBehaviour
{
    public RectTransform flashlightMask; // The dark panel with transparent hole
    public GameObject furniture;         // Real object to reveal
    public float revealRadius = 80f;     // Match your transparent hole's size

    private RectTransform myRect;

    void Start()
    {
        myRect = GetComponent<RectTransform>();
        GameManagerLanterna.Instance.RegisterMonster();
    }

    void Update()
    {
        if (furniture.activeSelf) return;

        // Get positions in the same local UI space
        Vector2 flashlightPos = flashlightMask.anchoredPosition;
        Vector2 monsterPos = myRect.anchoredPosition;

        float distance = Vector2.Distance(flashlightPos, monsterPos);

        if (distance < revealRadius)
        {
            furniture.SetActive(true);
            gameObject.SetActive(false);
            GameManagerLanterna.Instance.MonsterRevealed();
        }
    }
}
