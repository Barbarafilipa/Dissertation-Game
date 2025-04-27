using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StickerData", menuName = "Game/StickerData")]
public class StickerData : ScriptableObject
{
    public List<string> collectedStickers = new List<string>();

    public void AddSticker(string sticker)
    {
        if (!collectedStickers.Contains(sticker))
        {
            collectedStickers.Add(sticker);
            Debug.Log("Sticker added: " + sticker);
        }
    }

    public List<string> GetCollectedStickers()
    {
        return new List<string>(collectedStickers); // Return a copy of the list
    }

    public void ClearStickers()
    {
        collectedStickers.Clear();
        Debug.Log("Sticker data cleared.");
    }
}