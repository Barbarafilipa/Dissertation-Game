using UnityEngine;
using UnityEngine.UI;

public class ComidaReveal : MonoBehaviour
{
    public RectTransform foodItem;
    private Image foodToReveal;
    private RectTransform myRect;
    private Color blackColor = new Color(0, 0, 0, 1); // Black color with full opacity
    private Color whiteColor = new Color(1, 1, 1, 1); // White color with full opacity

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myRect = GetComponent<RectTransform>();
        GameManagerPrato.Instance.RegisterFoodItem();
        foodToReveal = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check color of the object attached to this script
        if (foodToReveal.color != blackColor) return;
        
        // Get positions in the same local UI space
        Vector2 foodItemPos = foodItem.anchoredPosition;
        Vector2 finalPos = myRect.anchoredPosition;

        float distance = Vector2.Distance(foodItemPos, finalPos);

        if (distance < 80f) // Match your transparent hole's size
        {
            foodToReveal.color = whiteColor; // Change color to white
            GameManagerPrato.Instance.FoodItemRevealed();

            foodItem.gameObject.SetActive(false);
        }
    }
}
