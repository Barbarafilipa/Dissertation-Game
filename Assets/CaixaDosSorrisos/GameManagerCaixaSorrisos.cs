using UnityEngine;

public class GameManagerCaixaSorrisos : MonoBehaviour
{
    public static GameManagerCaixaSorrisos Instance;
    [SerializeField] private MinigameManager minigameManager;

    void Awake()
    {
        Instance = this;
    }


    public void AllEmotionsCollected()
    {
        // Wait for a second before ending the game
        Invoke("CompleteMinigame", 1f);
    }

    public void CompleteMinigame()
    {
        // Logic to complete the minigame
        Debug.Log("Minigame completed!");
        minigameManager.CompleteMinigame();
    }
}
