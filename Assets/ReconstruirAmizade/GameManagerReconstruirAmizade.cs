using UnityEngine;

public class GameManagerReconstruirAmizade : MonoBehaviour
{
    public static GameManagerReconstruirAmizade Instance;
    [SerializeField] private MinigameManager minigameManager;

    void Awake()
    {
        Instance = this;
    }

    public void CompleteMinigame()
    {
        // Logic to complete the minigame
        Debug.Log("Minigame completed!");
        minigameManager.CompleteMinigame();
    }
}
