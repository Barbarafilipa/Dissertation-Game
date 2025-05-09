using UnityEngine;

public class GameManagerCanos : MonoBehaviour
{
    public static GameManagerCanos Instance;
    [SerializeField] private MinigameManager minigameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
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
