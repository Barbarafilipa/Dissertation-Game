using UnityEngine;

public class GameManagerCaixaSorrisos : MonoBehaviour
{
    public static GameManagerCaixaSorrisos Instance;
    private int remainingEmotions;
    [SerializeField] private MinigameManager minigameManager;

    void Awake()
    {
        Instance = this;
    }

    public void RegisterEmotion()
    {
        remainingEmotions++;
    }

    public void EmotionRevealed()
    {
        remainingEmotions--;
        Debug.Log("Emotion revealed! Remaining: " + remainingEmotions);
        if (remainingEmotions <= 0)
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
