using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChoseCharacter : MonoBehaviour
{
    [SerializeField] private GameObject[] characters;
    public GameObject previousButton;
    public GameObject nextButton;
    public TMP_InputField characterNameInputField;
    private int currentIndex = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetCurrentIndex();
        SetCharacterNameOnInputField();

        for (int i = 0; i < characters.Length; i++)
        {
            if (currentIndex == i)
                characters[i].SetActive(true);
            else
                characters[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NextCharacter()
    {
        characters[currentIndex].SetActive(false);
        currentIndex = (currentIndex + 1) % characters.Length;
        characters[currentIndex].SetActive(true);

        SaveCharacterInfo();
    }

    public void PreviousCharacter()
    {
        characters[currentIndex].SetActive(false);
        currentIndex = (currentIndex - 1 + characters.Length) % characters.Length;
        characters[currentIndex].SetActive(true);

        SaveCharacterInfo();
    }

    private void SetCharacterNameOnInputField()
    {
        string characterName = PlayerPrefs.GetString("Name");
        if (string.IsNullOrEmpty(characterName))
            characterName = "";

        characterNameInputField.text = characterName;
    }

    private void SetCurrentIndex()
    {
        string characterName = PlayerPrefs.GetString("Character");
        for (int i = 0; i < characters.Length; i++)
        {
            if (characters[i].name == characterName)
            {
                currentIndex = i;
                break;
            }
        }
    }

    public void SaveCharacterInfo()
    {
        PlayerPrefs.SetString("Character", characters[currentIndex].name);
        PlayerPrefs.SetString("Name", characterNameInputField.text);
        PlayerPrefs.Save();
    }
}
