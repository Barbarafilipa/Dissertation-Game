using UnityEngine;
using UnityEngine.EventSystems;

public class MoveLeftRight : MonoBehaviour, IDragHandler
{
    private RectTransform rectTransform;
    private Canvas canvas;

    [SerializeField] private RectTransform boundaryPanel; // The panel you want to restrict movement inside
    [SerializeField] private float horizontalMargin = 20f; // Margin in pixels from each side

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Move only horizontally
        float deltaX = eventData.delta.x / canvas.scaleFactor;
        Vector2 newPos = rectTransform.anchoredPosition + new Vector2(deltaX, 0);

        ClampToPanel(ref newPos);

        rectTransform.anchoredPosition = newPos;
    }

    private void ClampToPanel(ref Vector2 position)
    {
        RectTransform parent = rectTransform.parent as RectTransform;

        Vector3[] panelCorners = new Vector3[4];
        boundaryPanel.GetWorldCorners(panelCorners);

        Vector3[] localCorners = new Vector3[4];
        for (int i = 0; i < 4; i++)
        {
            localCorners[i] = parent.InverseTransformPoint(panelCorners[i]);
        }

        float leftLimit = localCorners[0].x + rectTransform.rect.width * rectTransform.pivot.x + horizontalMargin;
        float rightLimit = localCorners[3].x - rectTransform.rect.width * (1f - rectTransform.pivot.x) - horizontalMargin;

        position.x = Mathf.Clamp(position.x, leftLimit, rightLimit);
    }
}
