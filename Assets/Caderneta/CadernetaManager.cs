using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class CadernetaManager : MonoBehaviour
{
    public static CadernetaManager instance;

    [Header("Sticker Slots")]
    [SerializeField] private List<GameObject> stickerSlots; // UI slots for stickers
    public List<GameObject> pages;
    private int currentPageIndex = 1;

    public GameObject nextButton;
    public GameObject previousButton;

    [Header("Sticker Data")]
    [SerializeField] private StickerData stickerData; // Reference to the StickerData scriptable object
    [SerializeField] private GameObject stickerPrefab; // Prefab for stickers

    [Header("Sticker Inventory")]
    [SerializeField] private Transform stickerInventoryParent; // Parent object for sticker inventory
    private List<GameObject> stickerInventory = new List<GameObject>(); // List of sticker objects in inventory

    [Header("Sticker Sprites")]
    [SerializeField] private List<StickerSprite> stickerSpriteMappings; // List of sticker-to-sprite mappings
    private Dictionary<string, Sprite> stickerSprites; // Internal dictionary for quick lookup
    private List<string> placedStickers = new List<string>(); // Track stickers placed in the notebook

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        placedStickers = stickerData.GetPlacedStickers(); // Get the list of placed stickers from StickerData
        Debug.Log("Placed stickers: " + string.Join(", ", placedStickers));

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
        foreach (string stickerName in placedStickers)
        {
            if (stickerSprites.ContainsKey(stickerName))
            {
                // Update the corresponding slot with the sticker sprite
                int slotIndex = placedStickers.IndexOf(stickerName);
                if (slotIndex < stickerSlots.Count)
                {
                    PlaceSticker(stickerSprites[stickerName], stickerName, stickerSlots[slotIndex]);
                }
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
                sticker.name = stickerName; // Set the name of the sticker object

                int slotIndex = stickerSprites.Keys.ToList().IndexOf(stickerName);
                sticker.GetComponent<DragSelo>().correspondingSlot = stickerSlots[slotIndex].GetComponent<RectTransform>();
                stickerInventory.Add(sticker);
            }
        }
    }

    private void Update()
    {
        // Update button visibility based on current page index
        previousButton.SetActive(currentPageIndex > 1);
        nextButton.SetActive(currentPageIndex < pages.Count);
    }

    public void NextPage()
    {
        Debug.Log("Next Page");
        if (currentPageIndex < pages.Count)
        {
            pages[currentPageIndex - 1].SetActive(false);
            currentPageIndex++;
            pages[currentPageIndex - 1].SetActive(true);
        }
    }

    public void PreviousPage()
    {
        Debug.Log("Previous Page");
        if (currentPageIndex > 0)
        {
            pages[currentPageIndex - 1].SetActive(false);
            currentPageIndex--;
            pages[currentPageIndex - 1].SetActive(true);
        }
    }

    public void PlaceSticker(Sprite selo, string stickerName, GameObject correspondingSlot)
    {
        // Set the sprite of the empty slot
        correspondingSlot.transform.Find("Selo").GetComponent<Image>().sprite = selo;

        // Get children with the names "Explicação", "Desconhecido", and "Number"
        GameObject explicacao = correspondingSlot.transform.Find("Explicação").gameObject;
        GameObject desconhecido = correspondingSlot.transform.Find("Desconhecido").gameObject;
        GameObject number = correspondingSlot.transform.Find("Number").gameObject;

        explicacao.SetActive(true); // Show the explanation
        number.SetActive(false); // Hide the number
        desconhecido.SetActive(false); // Hide the unknown

        stickerData.PlaceSticker(stickerName); // Update the sticker data
        Debug.Log("CADERNETA - Sticker placed: " + stickerName);
    }
}
