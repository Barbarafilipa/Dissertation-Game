using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ComidaDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector3 originalPosition;
    private RectTransform rectTransform;
    private Canvas canvas;

    [Header("Optional Target Match")]
    public RectTransform targetSlot;   // Only set if there is a matching plate slot
    public Image targetImage;          // The black-to-white image (optional)
    public GameObject foodName;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        originalPosition = rectTransform.anchoredPosition;
        canvas = GetComponentInParent<Canvas>();
    }

    void Start()
    {
        // Only register the food item if it is has a target slot
        if (targetSlot != null)
        {
            GameManagerPrato.Instance.RegisterFoodItem(); // Register the food item
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        rectTransform.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (targetSlot != null &&
            RectTransformUtility.RectangleContainsScreenPoint(targetSlot, eventData.position, eventData.pressEventCamera))
        {
            if (targetImage != null)
                targetImage.color = Color.white;

            GameManagerPrato.Instance.FoodItemRevealed();
            gameObject.SetActive(false); // Hide the dragged item
            foodName.SetActive(false); // Hide the food name
        }
        else
        {
            rectTransform.anchoredPosition = originalPosition; // Snap back
        }
    }
}
