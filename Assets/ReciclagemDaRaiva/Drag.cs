using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector3 originalPosition;
    private RectTransform rectTransform;
    private Canvas canvas;
    [Header("Optional Target Match")]
    public RectTransform targetSlot;   // Only set if there is a matching plate slot

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        originalPosition = rectTransform.anchoredPosition;
        canvas = GetComponentInParent<Canvas>();
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
            // If the dragged item is dropped on the target slot
            gameObject.SetActive(false);
            GameManagerReciclagem.Instance.ThoughtRecycled(); // Notify the game manager
            Debug.Log("Dropped on target slot");
        }
        else
        {
            rectTransform.anchoredPosition = originalPosition;
        }
    }
}
