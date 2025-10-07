using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{
    public string level_name;    // e.g., "Level_2"
    public Sprite lockIcon;      // Optional: lock image over the button
    public Sprite unlockIcon;    // Optional: unlock image over the button

    private Button button;

    void Start()
    {
        button = GetComponent<Button>();
        bool isUnlocked;
        if (level_name == "Level_1")
        {
            isUnlocked = true; // Level 1 is always unlocked by default
        }
        else
        {
            // Current button's level is unlocked if previous level is completed
            int previousLevel = int.Parse(level_name.Split('_')[1]) - 1;
            isUnlocked = PlayerPrefs.GetInt("Level_" + previousLevel, 0) == 1;
        }

        button.interactable = isUnlocked;
        // If the level is unlocked, change the image to the unlock icon
        button.image.sprite = isUnlocked ? unlockIcon : lockIcon;
    }
}
