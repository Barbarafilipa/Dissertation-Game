using UnityEngine;
using UnityEngine.EventSystems;

public class Sticker : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private CanvasGroup canvasGroup;
    private RectTransform rectTransform;
    private Transform originalParent;

    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalParent = transform.parent;
        canvasGroup.blocksRaycasts = false; // Allow the sticker to pass through drop zones
        canvasGroup.alpha = 0.6f; // Make the sticker semi-transparent while dragging
        transform.SetParent(transform.root); // Move to the root to avoid clipping issues
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / transform.lossyScale; // Move the sticker with the cursor
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true; // Re-enable raycasts
        canvasGroup.alpha = 1f; // Restore full opacity

        // If not dropped on a valid slot, return to the original position
        if (transform.parent == transform.root)
        {
            transform.SetParent(originalParent);
            rectTransform.anchoredPosition = Vector2.zero;
        }
    }
}