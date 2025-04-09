using UnityEngine;
using UnityEngine.EventSystems;

public class StickerSlot : MonoBehaviour, IDropHandler
{
    public bool IsOccupied { get; private set; } = false;

    public void OnDrop(PointerEventData eventData)
    {
        if (!IsOccupied && eventData.pointerDrag != null)
        {
            // Attach the sticker to this slot
            GameObject draggedSticker = eventData.pointerDrag;
            draggedSticker.transform.SetParent(transform);
            draggedSticker.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;

            IsOccupied = true; // Mark the slot as occupied
        }
    }
}