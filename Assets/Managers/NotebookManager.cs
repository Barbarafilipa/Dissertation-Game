using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotebookManager : MonoBehaviour
{
    [Header("Sticker Slots")]
    [SerializeField] private List<Image> stickerSlots; // UI slots for stickers
    [SerializeField] private Sprite defaultStickerSprite; // Default empty slot sprite
    [SerializeField] private GameObject stickerPrefab; // Prefab for stickers

    [Header("Sticker Sprites")]
    [SerializeField] private List<StickerSprite> stickerSpriteMappings; // List of sticker-to-sprite mappings

    [Header("Sticker Data")]
    [SerializeField] private StickerData stickerData; // Reference to the StickerData scriptable object

    private Dictionary<string, Sprite> stickerSprites; // Internal dictionary for quick lookup

    void Start()
    {
        // Initialize the dictionary from the serialized list
        stickerSprites = new Dictionary<string, Sprite>();
        foreach (StickerSprite mapping in stickerSpriteMappings)
        {
            if (!stickerSprites.ContainsKey(mapping.stickerName))
            {
                stickerSprites.Add(mapping.stickerName, mapping.sprite);
            }
        }

        // Initialize sticker slots with default sprites
        foreach (Image slot in stickerSlots)
        {
            slot.sprite = defaultStickerSprite;
        }

        UpdateNotebook(); // Initialize the notebook UI on start
    }

    public void UpdateNotebook()
    {
        // Get collected stickers from StickerData
        List<string> collectedStickers = stickerData.GetCollectedStickers();

        // Update the notebook UI
        for (int i = 0; i < stickerSlots.Count; i++)
        {
            if (i < collectedStickers.Count)
            {
                string stickerName = collectedStickers[i];
                if (stickerSprites.ContainsKey(stickerName))
                {
                    stickerSlots[i].sprite = stickerSprites[stickerName];
                }
            }
            else
            {
                stickerSlots[i].sprite = defaultStickerSprite; // Empty slot
            }
        }
    }
}