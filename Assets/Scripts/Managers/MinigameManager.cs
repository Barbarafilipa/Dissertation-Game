using UnityEngine;
using System.Collections.Generic;

public class MinigameManager : MonoBehaviour
{
    public DialogManager dialogManager;
    //public RewardManager rewardManager; // Reference to the RewardManager

    [Header("Minigame Screens")]
    [SerializeField] private GameObject[] minigames;

    private Dictionary<string, GameObject> minigameDictionary;
    private GameObject activeMinigame;

    void Start()
    {
        // Initialize dictionary with all minigames
        minigameDictionary = new Dictionary<string, GameObject>();
        foreach (GameObject minigame in minigames)
        {
            minigameDictionary[minigame.name] = minigame;
            minigame.SetActive(false); // Ensure they're all hidden at start
        }
    }

    public void StartMinigame(string minigameName)
    {
        if (!minigameDictionary.ContainsKey(minigameName))
        {
            Debug.LogError("No minigame was found with the name: " + minigameName);
            return;
        }

        activeMinigame = minigameDictionary[minigameName];
        activeMinigame.SetActive(true);

        Debug.Log("Started minigame: " + minigameName);
    }

    public void CompleteMinigame()
    {
        if (activeMinigame != null)
        {
            activeMinigame.SetActive(false);
            Debug.Log("Completed minigame: " + activeMinigame.name);

            // Reward the player using RewardManager
            //rewardManager.RewardSticker(activeMinigame.name);

            activeMinigame = null;
        }

        dialogManager.ResumeDialogue(); // Resume dialogue after minigame
    }
}
