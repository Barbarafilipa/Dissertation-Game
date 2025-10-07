using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    [Header("Game Data")]
    [SerializeField] private StickerData gameData;
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        ClearPlayerPrefs();
        gameData.LoadStickers();

        if (!PlayerPrefs.HasKey("GameCompleted"))
        {
            PlayerPrefs.SetInt("GameCompleted", 0);
            PlayerPrefs.Save();
        }

        if (!PlayerPrefs.HasKey("TutorialCompleted"))
        {
            PlayerPrefs.SetInt("TutorialCompleted", 0);
            PlayerPrefs.Save();
        }

        // Unlock Level 1 by default, if not already done
        if (!PlayerPrefs.HasKey("Level_1"))
        {
            PlayerPrefs.SetInt("Level_1", 0);
            PlayerPrefs.Save();
        }

        if (!PlayerPrefs.HasKey("Character") || string.IsNullOrEmpty(PlayerPrefs.GetString("Character")))
        {
            PlayerPrefs.SetString("Character", "Boy");
            PlayerPrefs.Save();
        }

        // Initialize character info
        if (!PlayerPrefs.HasKey("Name") || string.IsNullOrEmpty(PlayerPrefs.GetString("Name")))
        {
            PlayerPrefs.SetString("Name", PlayerPrefs.GetString("Character") == "Boy" ? "João" : "Maria");
            PlayerPrefs.Save();
        }
    }

    private void ClearPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
    }
}
