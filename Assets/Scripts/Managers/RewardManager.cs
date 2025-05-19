using System.Collections.Generic;
using UnityEngine;

public class RewardManager : MonoBehaviour
{
    [Header("Sticker Rewards")]
    [SerializeField] private List<string> minigameStickers; // Maps minigame names to sticker names
    [SerializeField] private StickerData stickerData; // Reference to the StickerData scriptable object

    void Start()
    {
        // Initialize sticker rewards (example setup)
        minigameStickers = new List<string>
        {
            "Medo",
            "LanternaMagica",
            "MedalhaDaCoragem",
            "Nojo",
            "ChefDeCozinha",
            "ExploradorDeSabores",
            "Ciume",
            "CaixaDaAlegria",
            "CoracaoGrande",
            "Ansiedade",
            "PensamentoPositivo",
            "EscolhaInteligente",
            "RespiracaoTranquila",
            "DesafioSuperado",
            "Vergonha",
            "SuperEstrela",
            "SorrisoBrilhante",
            "Raiva",
            "ReciclagemDaRaiva",
            "MuroDaAmizade",
            "ConversaHonesta"
        };
    }

    public void RewardSticker(string stickerName)
    {
        if (minigameStickers.Contains(stickerName))
        {
            // Add sticker to the player's collection
            stickerData.AddSticker(stickerName);
        }
        else
        {
            Debug.LogWarning("No sticker reward found for minigame: " + stickerName);
        }
    }
}