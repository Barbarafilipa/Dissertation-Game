using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragSelo : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private Canvas canvas;
    private Transform originalParent;
    private Vector2 originalPosition;
    private Vector2 dragStartPosition;
    private bool isDragging = false;
    private bool directionDecided = false;
    private bool isHorizontalScroll = false;

    private CanvasGroup canvasGroup;
    private ScrollRect scrollRect;

    public RectTransform correspondingSlot;

    private float horizontalBias = 1.5f; // ← Só se for muito mais horizontal é scroll

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        dragStartPosition = eventData.position;
        originalParent = transform.parent;
        originalPosition = rectTransform.anchoredPosition;
        isDragging = false;
        directionDecided = false;
        isHorizontalScroll = false;

        scrollRect = GetComponentInParent<ScrollRect>();
        scrollRect?.OnBeginDrag(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!directionDecided)
        {
            Vector2 delta = eventData.position - dragStartPosition;

            if (delta.magnitude > 10f)
            {
                if (Mathf.Abs(delta.x) > Mathf.Abs(delta.y) * horizontalBias)
                {
                    // Claramente um scroll horizontal
                    isHorizontalScroll = true;
                }
                else
                {
                    // Qualquer outro caso (diagonal, vertical, etc.) → drag
                    isDragging = true;
                    transform.SetParent(transform.root);
                    canvasGroup.blocksRaycasts = false;
                }

                directionDecided = true;
            }
        }

        if (isDragging)
        {
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }
        else if (isHorizontalScroll && scrollRect != null)
        {
            scrollRect.OnDrag(eventData);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (isDragging)
        {
            if (correspondingSlot != null &&
                RectTransformUtility.RectangleContainsScreenPoint(correspondingSlot, eventData.position, eventData.pressEventCamera))
            {
                Sprite selo = GetComponent<Image>().sprite;
                CadernetaManager.instance.PlaceSticker(selo, gameObject.name, correspondingSlot.gameObject);
                Destroy(gameObject);
                return;
            }

            transform.SetParent(originalParent);
            rectTransform.anchoredPosition = originalPosition;
            canvasGroup.blocksRaycasts = true;
        }
        else if (isHorizontalScroll && scrollRect != null)
        {
            scrollRect.OnEndDrag(eventData);
        }
    }
}
