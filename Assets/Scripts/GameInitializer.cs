using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        // Unlock Level 1 by default, if not already done
        if (!PlayerPrefs.HasKey("Level_1"))
        {
            PlayerPrefs.SetInt("Level_1", 1);
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
}
