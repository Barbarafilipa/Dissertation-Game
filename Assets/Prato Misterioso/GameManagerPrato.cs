using UnityEngine;

public class GameManagerPrato : MonoBehaviour
{
    public static GameManagerPrato Instance;
    private int remainingFoodItems;
    [SerializeField] private MinigameManager minigameManager;

    void Awake()
    {
        Instance = this;
    }

    public void RegisterFoodItem()
    {
        remainingFoodItems++;
    }

    public void FoodItemRevealed()
    {
        remainingFoodItems--;
        Debug.Log("Food item revealed! Remaining: " + remainingFoodItems);
        if (remainingFoodItems <= 0)
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
