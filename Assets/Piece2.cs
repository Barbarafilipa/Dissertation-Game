using UnityEngine;

public class Piece2 : MonoBehaviour
{
    private Vector3 originalPosition;
    private float originalZ;
    private bool isDragging = false;
    private Camera mainCam;
    private Collider2D pieceCollider;
    private GameManager gameManager;

    void Start()
    {
        mainCam = Camera.main;
        gameManager = FindFirstObjectByType<GameManager>();
        pieceCollider = GetComponent<Collider2D>(); // Get the collider reference
    }

    void OnMouseDown()
    {
        originalPosition = transform.localPosition;
        originalZ = transform.position.z;
        isDragging = true;

        // Disable the collider temporarily
        pieceCollider.enabled = false;

        // Bring it forward visually
        Vector3 newPos = transform.position;
        newPos.z = -0.1f; // A bit in front
        transform.position = newPos;

        //Debug.Log("Moving piece: " + this.name);
    }

    void OnMouseDrag()
    {
        if (!isDragging) return;

        Vector3 mouseWorldPos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = -0.1f; // Keep it in front while dragging
        transform.position = mouseWorldPos;
    }

    void OnMouseUp()
    {
        isDragging = false;

        // Restore Z temporarily so the raycast can hit this again if needed
        transform.position = new Vector3(transform.position.x, transform.position.y, 0f);

        // Raycast to check if we dropped on another piece
        Vector2 mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

        if (hit.collider != null)
        {
            Piece targetPiece = hit.collider.GetComponent<Piece>();

            Debug.Log("Hit piece: " + targetPiece.name);

            if (targetPiece != null && targetPiece != this)
            {
                Debug.Log("Swap with: " + targetPiece.name);
                
                // Swap positions!
                Vector3 temp = targetPiece.transform.localPosition;
                targetPiece.transform.localPosition = this.originalPosition;
                this.transform.localPosition = temp;

                //gameManager.SwapPieces(targetPiece, this);

                // Re-enable the collider when you're done
                pieceCollider.enabled = true;
                return;
            }
        }

        // If no valid target found, snap back to original position
        transform.localPosition = originalPosition;

        // Re-enable the collider when you're done
        pieceCollider.enabled = true;
    }
}
