using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class MoveFlashlight : MonoBehaviour
{
    [SerializeField] private Camera uiCamera; // Can be null if using Screen Space - Overlay

    private RectTransform parentRectTransform;
    private RectTransform flashlightRect;

    void Start()
    {
        flashlightRect = GetComponent<RectTransform>();
        parentRectTransform = transform.parent.GetComponent<RectTransform>();

        // Start flashlight in the center
        flashlightRect.localPosition = Vector2.zero;
    }

    void Update()
    {
        Vector2 pointerPosition;

        if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.isPressed)
        {
            pointerPosition = Touchscreen.current.primaryTouch.position.ReadValue();
        }
        else if (Mouse.current != null && Mouse.current.leftButton.isPressed)
        {
            pointerPosition = Mouse.current.position.ReadValue();
        }
        else
        {
            return; // Don't move if there's no active touch/click
        }

        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            parentRectTransform,
            pointerPosition,
            uiCamera,
            out localPoint
        );

        flashlightRect.localPosition = localPoint;
    }
}
