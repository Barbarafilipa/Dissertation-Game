using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class MoveFlashlight : MonoBehaviour
{
    [SerializeField] private Camera uiCamera; // Reference to the canvas's camera

    void Update()
    {
        Vector2 mousePos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            transform.parent.GetComponent<RectTransform>(),
            Touchscreen.current.position.ReadValue(),
            uiCamera, // ← Pass the correct camera here
            out mousePos
        );
        transform.localPosition = mousePos;
    }
}
