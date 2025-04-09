using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Piece : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector2 originalPosition;
    private RectTransform rectTransform;
    private Canvas canvas;
    private GameManager gameManager;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        gameManager = FindFirstObjectByType<GameManager>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalPosition = rectTransform.anchoredPosition;

        // Bring this piece to the front (last sibling in the hierarchy = top in UI)
        rectTransform.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Perform a UI raycast to find the drop target
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);

        foreach (RaycastResult result in results)
        {
            if (result.gameObject == this.gameObject) continue;

            Piece otherPiece = result.gameObject.GetComponent<Piece>();
            if (otherPiece != null)
            {
                // Swap anchored positions
                SwapPieces(this, otherPiece);
                return;
            }
        }

        // No valid target, snap back
        rectTransform.anchoredPosition = originalPosition;
    }

    public void SwapPieces(Piece a, Piece b)
    {
        Vector2 temp = b.rectTransform.anchoredPosition;
        b.rectTransform.anchoredPosition = a.originalPosition;
        a.rectTransform.anchoredPosition = temp;
        gameManager.SwapPieces(a, b);
    }

}
