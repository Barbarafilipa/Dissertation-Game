using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragPiece : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
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
            targetSlot.gameObject.GetComponent<UnityEngine.UI.Image>().color = Color.white; // Change the color of the target slot to white

            // If the dragged item is dropped on the target slot
            gameObject.SetActive(false);
            GameManagerReconstruirAmizade.Instance.PieceRevealed(); // Notify the game manager
        }
        else
        {
            rectTransform.anchoredPosition = originalPosition;
        }
    }
}
