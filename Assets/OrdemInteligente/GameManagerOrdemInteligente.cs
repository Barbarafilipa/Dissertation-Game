using UnityEngine;

public class GameManagerOrdemInteligente : MonoBehaviour
{
    public static GameManagerOrdemInteligente Instance;
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