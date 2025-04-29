using UnityEngine;

public class GameManagerPrato : MonoBehaviour
{
    [SerializeField] private MinigameManager minigameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CompleteMinigame()
    {
        // Logic to complete the minigame
        Debug.Log("Minigame completed!");
        minigameManager.CompleteMinigame();
    }
}
