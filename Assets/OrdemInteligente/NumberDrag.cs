using UnityEngine;
using UnityEngine.EventSystems;

public class NumberDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector3 originalPosition;
    private RectTransform rectTransform;
    private Canvas canvas;
    public RectTransform targetSlot; // Only set if there is a matching plate slot
    public RectTransform solutionSlot;
    public GameObject warningText;

    private void Awake()
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
            // Check if previous question was answered
            if (targetSlot.gameObject.name == "Second" && !GameManagerOrdemInteligente.Instance.isFirstAnswered)
            {
                warningText.GetComponent<Animator>().Play("FadeOut");
                rectTransform.anchoredPosition = originalPosition; // Snap back
                return;
            }

            if(targetSlot.gameObject.name == "Third" && (!GameManagerOrdemInteligente.Instance.isFirstAnswered || !GameManagerOrdemInteligente.Instance.isSecondAnswered))
            {
                warningText.GetComponent<Animator>().Play("FadeOut");
                rectTransform.anchoredPosition = originalPosition; // Snap back
                return;
            }

            if(targetSlot.gameObject.name == "First") GameManagerOrdemInteligente.Instance.isFirstAnswered = true;
            if(targetSlot.gameObject.name == "Second") GameManagerOrdemInteligente.Instance.isSecondAnswered = true;
            
            targetSlot.gameObject.SetActive(false); // Hide the target slot
            solutionSlot.gameObject.SetActive(true); // Show the solution slot
            gameObject.SetActive(false); // Hide the dragged item
            GameManagerOrdemInteligente.Instance.NumberRevealed(); // Notify the game manager
            return;
        }
        rectTransform.anchoredPosition = originalPosition; // Snap back
    }
}
