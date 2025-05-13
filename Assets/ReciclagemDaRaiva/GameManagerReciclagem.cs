using UnityEngine;

public class GameManagerReciclagem : MonoBehaviour
{
    public static GameManagerReciclagem Instance;
    [SerializeField] private MinigameManager minigameManager;
    private int remainingThoughts = 10;

    void Awake()
    {
        Instance = this;
    }

    public void ThoughtRecycled()
    {
        remainingThoughts--;
        if (remainingThoughts <= 0)
        {
            // Wait for a second before ending the game
            Invoke("CompleteMinigame", 1f);
        }
    }

    public void CompleteMinigame()
    {
        // Logic to complete the minigame
        Debug.Log("Minigame completed!");
        minigameManager.CompleteMinigame();
    }
}
