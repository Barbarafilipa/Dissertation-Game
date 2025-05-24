using Unity.VisualScripting;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;
using Ink.Runtime;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Playables;
using UnityEngine.InputSystem;


public class DialogManager : MonoBehaviour
{

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    [Header("Managers")]
    [SerializeField] private MinigameManager minigameManager;
    [SerializeField] private RewardManager rewardManager;

    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;

    [SerializeField] private Animator portraitAnimator;
    [SerializeField] private GameObject confettis;

    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;

    [Header("Characters")]
    [SerializeField] private GameObject[] characters;
    [SerializeField] private RuntimeAnimatorController boyAnimator;
    [SerializeField] private RuntimeAnimatorController girlAnimator;

    [Header("Other UI Elements")]
    [SerializeField] private GameObject[] otherUIElements;

    private Story currentStory;
    private bool dialogueIsPlaying;
    private bool isExitingLevel = false; // Flag to check if exiting the level
    public string currentLevelName;
    private const string SPEAKER_TAG = "speaker";
    private const string PORTRAIT_TAG = "portrait";
    private const string ANIMATION_TAG = "animation";
    private const string SHOW_TAG = "show";
    private const string HIDE_TAG = "hide";
    private const string MINIGAME_TAG = "minigame";
    private const string STICKER_TAG = "sticker";
    private const string AUDIO_TAG = "audio";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetCharacter();
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);

        // get all of the choices text
        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach (GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
        
        EnterDialogueMode(inkJSON);
    }

    // Update is called once per frame
    private void Update()
    {
        // return right away if dialogue isn't playing
        if(!dialogueIsPlaying || isExitingLevel)
        {
            return;
        }

        // Prevent continuing the story if choices are being displayed
        if (currentStory.currentChoices.Count > 0)
        {
            return;
        }
    
        if (Touchscreen.current == null) return;

        if (Touchscreen.current.primaryTouch.press.wasPressedThisFrame)
        {
            // Stop any audio that is currently playing
            AudioManager.Instance.StopAudio();
            if (IsTouchOverUI())
            {
                return;
            }
            ContinueStory();
        }
    }

    private bool IsTouchOverUI()
    {
        PointerEventData pointerData = new PointerEventData(EventSystem.current)
        {
            position = Touchscreen.current.primaryTouch.position.ReadValue()
        };

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerData, results);

        foreach (RaycastResult result in results)
        {
            if (result.gameObject.name == "ExitButton" || result.gameObject.name == "AudioButton") // Replace "ExitButton" with your button's name
            {
                return true;
            }
        }

        return false;
    }

    private void SetCharacter()
    {
        GameObject child = null;
        foreach (GameObject character in characters)
        {
            if (character.name == "Child")
            {
                child = character;
                break;
            }
        }

        if (!PlayerPrefs.HasKey("Character") || PlayerPrefs.GetString("Character") == "Boy")
        {
            // Change child animator to boyAnimator
            child.GetComponent<Animator>().runtimeAnimatorController = boyAnimator;
        }
        else if (PlayerPrefs.GetString("Character") == "Girl")
        {
            // Change child animator to girlAnimator
            child.GetComponent<Animator>().runtimeAnimatorController = girlAnimator;
        }
    }

    public void EnterDialogueMode(TextAsset inkJSON)
    {
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);

        ContinueStory();
    }

    private void ContinueStory()
    {
        if(currentStory.canContinue)
        {
            // set text for the current dialogue line
            dialogueText.text = currentStory.Continue();

            CheckIfIsEndOfDialogue();

            // display choices, if any, for this dialogue line
            DisplayChoices();

            // handle tags
            HandleTags(currentStory.currentTags);
        }
        else
        {
            // If the story has ended, exit the level
            PlayerPrefs.SetInt(currentLevelName, 1); // Save the level as completed
            PlayerPrefs.Save();
            ExitLevel();
        }
    }

    private void CheckIfIsEndOfDialogue()
    {
        if (!currentStory.canContinue && currentStory.currentChoices.Count == 0)
        {
            Debug.Log("Last line of dialogue reached.");
            // Find the GameObject in the scene named Confettis
            
            if (confettis != null)
            {
                confettis.SetActive(true);
            }
        }
    }

    private void HandleTags(List<string> currentTags)
    {
        // Loop through each tag and handle it accordingly
        foreach (string tag in currentTags)
        {
            // parse the tag into a key value pair
            string[] splitTag = tag.Split(':');
            if (splitTag.Length != 2)
            {
                Debug.LogError("Tag could not be appropriately parsed: " + tag);
            }
            string tagKey = splitTag[0].Trim();
            string tagValue = splitTag[1].Trim();

            // handle the tag
            switch (tagKey)
            {
                case SPEAKER_TAG:
                    MakeSpeakerVisible(tagValue);
                    break;
                case PORTRAIT_TAG:
                    portraitAnimator.Play(tagValue);
                    Debug.Log("Playing animation: " + tagValue);
                    break;
                case ANIMATION_TAG:
                    HandleCharacterAnimation(tagValue);
                    break;
                case SHOW_TAG:
                    ShowUiElement(tagValue);
                    break;
                case HIDE_TAG:
                    HideUiElement(tagValue);
                    break;
                case MINIGAME_TAG:
                    PlayMinigame(tagValue);
                    break;
                case STICKER_TAG:
                    rewardManager.RewardSticker(tagValue);
                    break;
                case AUDIO_TAG:
                    AudioManager.Instance.PlayAudio(tagValue);
                    break;
                default:
                    Debug.LogWarning("Tag came in but is not currently being handled: " + tag);
                    break;
            }
        }
    }

    private void HandleCharacterAnimation(string tagValue)
    {
        string[] splitTag = tagValue.Split('_');
        if (splitTag.Length != 2)
        {
            Debug.LogError("Animation tag could not be appropriately parsed: " + tagValue);
            return;
        }
        string characterName = splitTag[0].Trim();
        string animationName = splitTag[1].Trim();

        GameObject character = null;
        // Find the character GameObject by name
        foreach (GameObject characterObj in characters)
        {
            if (characterObj.name == characterName)
            {
                character = characterObj;
                break;
            }
        }
        if (character == null)
        {
            Debug.LogError("Character not found: " + characterName);
            return;
        }
        character.GetComponent<Animator>().Play(animationName);
        Debug.Log("Playing animation: " + animationName + " for character: " + characterName);
    }

    private void DealWithMask(GameObject uiElement, bool show)
    {
        uiElement.GetComponent<Mask>().enabled = show;
    }
    private void DealWithTimeline(GameObject uiElement, bool show)
    {
        // Enable timeline component
        uiElement.GetComponent<PlayableDirector>().enabled = show;
    }

    private void ShowUiElement(string tagValue)
    {
        // Loop through all other UI elements and set the active state based on the tag value
        foreach (GameObject uiElement in otherUIElements)
        {
            if(uiElement.name == "Mask" && tagValue == "Mask") {
                DealWithMask(uiElement, true);
                return;
            }
            if(uiElement.name == "Timeline" && tagValue == "Timeline") {
                DealWithTimeline(uiElement, true);
                return;
            }
            if (uiElement.name == tagValue)
            {
                uiElement.SetActive(true);
                return; // Exit the loop once the UI element is found and activated
            }
        }
        Debug.LogWarning("UI element not found: " + tagValue);
    }

    private void HideUiElement(string tagValue)
    {
        // Loop through all other UI elements and set the active state based on the tag value
        foreach (GameObject uiElement in otherUIElements)
        {
            if(uiElement.name == "Mask" && tagValue == "Mask") {
                DealWithMask(uiElement, false);
                return;
            }
            if(uiElement.name == "Timeline" && tagValue == "Timeline") {
                DealWithTimeline(uiElement, false);
                return;
            }
            if (uiElement.name == tagValue)
            {
                uiElement.SetActive(false);
                return; // Exit the loop once the UI element is found and deactivated
            }
        }
        Debug.LogWarning("UI element not found: " + tagValue);
    }

    private void MakeSpeakerVisible(string speakerName)
    {
        // Find the corresponding GameObject for the speaker name and set it active
        foreach (GameObject character in characters)
        {
            if (character.name == speakerName)
            {
                character.SetActive(true);
                return; // Exit the loop once the character is found and activated
            }
        }
        Debug.LogWarning("Speaker not found: " + speakerName);
    }

    private void DisplayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;

        if (currentChoices.Count > choices.Length)
        {
            Debug.LogError("More choices were given than the UI can support. Number of choices given: " + currentChoices.Count);
        }

        int index = 0;
        // enable and initialize the choices up to the amount of choices for this line of dialogue
        foreach (Choice choice in currentChoices)
        {
            string[] splitText = choice.text.Split('$');
            Debug.Log("Split text: " + string.Join(", ", splitText));

            choices[index].gameObject.SetActive(true);
            choicesText[index].text = splitText[0];
            index++;

            string audioTag = splitText[1];
            audioTag = audioTag.Split(':')[1];

            // Tags for the choice
            Debug.Log("Audio tag: " + audioTag);
            
            // Find child object with the name AudioButton
            GameObject audioButton = choices[index - 1].gameObject.transform.GetChild(1).gameObject;
            // Remove the existing listener to avoid multiple calls
            audioButton.GetComponent<Button>().onClick.RemoveAllListeners();
            audioButton.GetComponent<Button>().onClick.AddListener(() => AudioManager.Instance.PlayAudio(audioTag));
        }

        // go through the remaining choices the UI supports and make sure they're hidden
        for (int i=index; i<choices.Length; i++)
        {
            choices[i].gameObject.SetActive(false);
        }
    }

    public void MakeChoice(int choiceIndex)
    {
        currentStory.ChooseChoiceIndex(choiceIndex);
        ContinueStory(); // Continue the story after making a choice
    }

    private void PlayMinigame(string tagValue)
    {
        minigameManager.StartMinigame(tagValue);
        dialogueIsPlaying = false; // pause dialogue
        dialoguePanel.SetActive(false);
    }

    public void ResumeDialogue()
    {
        dialoguePanel.SetActive(true);
        dialogueIsPlaying = true;

        ContinueStory(); // Resume the story after the minigame
    }

    public void ExitLevel()
    {
        // Exit the level and return to the main menu
        isExitingLevel = true; // Set the flag to indicate exiting the level

        SceneManager.LoadScene("Levels"); // Example: Load the main menu scene
    }
}
