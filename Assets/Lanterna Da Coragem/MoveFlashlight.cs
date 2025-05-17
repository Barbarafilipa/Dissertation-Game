using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class MoveFlashlight : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            transform.parent.GetComponent<RectTransform>(),
            Touchscreen.current.position.ReadValue(),
            null,
            out mousePos
        );
        transform.localPosition = mousePos;
    }
}
