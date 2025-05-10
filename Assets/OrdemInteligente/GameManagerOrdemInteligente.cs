using UnityEditor;
using UnityEngine;

public class GameManagerOrdemInteligente : MonoBehaviour
{
    public static GameManagerOrdemInteligente Instance;
    [SerializeField] private MinigameManager minigameManager;
    private int remainingNumbers = 3;

    void Awake()
    {
        Instance = this;
    }

    public void NumberRevealed()
    {
        remainingNumbers--;
        Debug.Log("Number revealed! Remaining: " + remainingNumbers);
        if (remainingNumbers <= 0)
        {
            // Wait for a second before ending the game
            Invoke("CompleteMinigame", 2f);
        }
    }

    public void CompleteMinigame()
    {
        // Logic to complete the minigame
        Debug.Log("Minigame completed!");
        minigameManager.CompleteMinigame();
    }
}