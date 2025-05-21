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

            CadernetaManager.instance.PlaceSticker(selo, gameObject.name, correspondingSlot.gameObject); // Call the method to place the sticker

            Destroy(gameObject); // Destroy the sticker after placing it
            return;
        }
        transform.SetParent(originalParent); // Return to original parent
        rectTransform.anchoredPosition = Vector2.zero; // Snap back
    }
}
