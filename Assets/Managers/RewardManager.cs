using System.Collections.Generic;
using UnityEngine;

public class RewardManager : MonoBehaviour
{
    [Header("Sticker Rewards")]
    [SerializeField] private Dictionary<string, string> minigameStickers; // Maps minigame names to sticker names
    [SerializeField] private StickerData stickerData; // Reference to the StickerData scriptable object

    void Start()
    {
        // Initialize sticker rewards (example setup)
        minigameStickers = new Dictionary<string, string>
        {
            { "PuzzleMedo", "Medo" },
            { "LanternaDaCoragem", "Lanterna Mágica" }
        };
    }

    public void RewardSticker(string minigameName)
    {
        if (minigameStickers.ContainsKey(minigameName))
        {
            string sticker = minigameStickers[minigameName];

            // Add sticker to the player's collection
            stickerData.AddSticker(sticker);
        }
        else
        {
            Debug.LogWarning("No sticker reward found for minigame: " + minigameName);
        }
    }
}