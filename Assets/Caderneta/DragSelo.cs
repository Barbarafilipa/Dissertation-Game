using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragSelo : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector3 originalPosition;
    private RectTransform rectTransform;
    private Canvas canvas;
    public RectTransform correspondingSlot;
    private Transform originalParent;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalParent = transform.parent;
        transform.SetParent(transform.root);
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (correspondingSlot != null && correspondingSlot.gameObject && RectTransformUtility.RectangleContainsScreenPoint(correspondingSlot, eventData.position, eventData.pressEventCamera))
        {
            Sprite selo = gameObject.GetComponent<Image>().sprite;
            // Get parent object of the empty slot
            GameObject slot = correspondingSlot.gameObject.transform.parent.gameObject;
            
            CadernetaManager.instance.PlaceSticker(selo, slot); // Call the method to place the sticker

            gameObject.SetActive(false); // Hide the dragged item
            return;
        }
        transform.SetParent(originalParent); // Return to original parent
        rectTransform.anchoredPosition = Vector2.zero; // Snap back
    }
}
