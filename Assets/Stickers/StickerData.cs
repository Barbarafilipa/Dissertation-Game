using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StickerData", menuName = "Game/StickerData")]
public class StickerData : ScriptableObject
{
    public List<string> collectedStickers = new List<string>();
    public List<string> placedStickers = new List<string>();

    private const string SaveKey = "StickerSaveData";

    public void AddSticker(string sticker)
    {
        if (!collectedStickers.Contains(sticker))
        {
            collectedStickers.Add(sticker);
            SaveStickers(); // Save immediately after adding
            Debug.Log("STICKER DATA - Sticker added: " + sticker);
        }
    }

    public void PlaceSticker(string sticker)
    {
        if (!placedStickers.Contains(sticker))
        {
            placedStickers.Add(sticker);
            collectedStickers.Remove(sticker); // Remove from collected list
            SaveStickers();
            Debug.Log("STICKER DATA - Sticker placed: " + sticker);
        }
    }

    public List<string> GetCollectedStickers()
    {
        return new List<string>(collectedStickers);
    }

    public List<string> GetPlacedStickers()
    {
        return new List<string>(placedStickers);
    }

    public void SaveStickers()
    {
        StickerSaveWrapper wrapper = new StickerSaveWrapper
        {
            collected = collectedStickers,
            placed = placedStickers
        };

        string json = JsonUtility.ToJson(wrapper);
        PlayerPrefs.SetString(SaveKey, json);
        PlayerPrefs.Save();
    }

    public void LoadStickers()
    {
        if (PlayerPrefs.HasKey(SaveKey))
        {
            string json = PlayerPrefs.GetString(SaveKey);
            StickerSaveWrapper wrapper = JsonUtility.FromJson<StickerSaveWrapper>(json);
            collectedStickers = wrapper.collected ?? new List<string>();
            placedStickers = wrapper.placed ?? new List<string>();
        }
    }

    [System.Serializable]
    private class StickerSaveWrapper
    {
        public List<string> collected;
        public List<string> placed;
    }
}
