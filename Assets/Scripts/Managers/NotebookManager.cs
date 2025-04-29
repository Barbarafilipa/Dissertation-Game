using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

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

    [Header("Sticker Inventory")]
    [SerializeField] private Transform stickerInventoryParent; // Parent object for sticker inventory
    private List<GameObject> stickerInventory = new List<GameObject>(); // List of sticker objects in inventory

    private Dictionary<string, Sprite> stickerSprites; // Internal dictionary for quick lookup
    private List<string> placedStickers = new List<string>(); // Track stickers placed in the notebook

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

        UpdateNotebook(); // Initialize the notebook UI on start
        UpdateInventory(); // Initialize the sticker inventory
    }

    public void UpdateNotebook()
    {
        // Update the notebook UI based on placed stickers
        for (int i = 0; i < stickerSlots.Count; i++)
        {
            if (i < placedStickers.Count)
            {
                string stickerName = placedStickers[i];
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

    public void UpdateInventory()
    {
        // Clear existing inventory
        foreach (Transform child in stickerInventoryParent)
        {
            Destroy(child.gameObject);
        }
        stickerInventory.Clear();

        // Get collected stickers from StickerData
        List<string> collectedStickers = stickerData.GetCollectedStickers();

        // Populate inventory with stickers that are not placed
        foreach (string stickerName in collectedStickers)
        {
            if (stickerSprites.ContainsKey(stickerName) && !placedStickers.Contains(stickerName))
            {
                GameObject sticker = Instantiate(stickerPrefab, stickerInventoryParent);
                sticker.GetComponent<Image>().sprite = stickerSprites[stickerName];
                stickerInventory.Add(sticker);
            }
        }
    }
}