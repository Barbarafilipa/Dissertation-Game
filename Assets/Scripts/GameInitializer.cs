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

        // You can add more initial setup here in the future
    }
}
