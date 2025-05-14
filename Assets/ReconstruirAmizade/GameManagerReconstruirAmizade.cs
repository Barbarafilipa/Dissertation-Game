using UnityEngine;

public class GameManagerReconstruirAmizade : MonoBehaviour
{
    public static GameManagerReconstruirAmizade Instance;
    [SerializeField] private MinigameManager minigameManager;
    private int remainingPieces = 3; // Number of pieces to be placed

    void Awake()
    {
        Instance = this;
    }

    public void PieceRevealed()
    {
        // Logic to handle when a piece is revealed
        remainingPieces--;
        if (remainingPieces <= 0)
        {
            Invoke("CompleteMinigame", 1f); // Call CompleteMinigame after 1 second
        }
    }

    public void CompleteMinigame()
    {
        // Logic to complete the minigame
        minigameManager.CompleteMinigame();
    }
}
