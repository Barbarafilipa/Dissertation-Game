using Unity.VisualScripting;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;
using Ink.Runtime;
using UnityEngine.EventSystems;

public class DialogManager : MonoBehaviour
{

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    [Header("Minigames")]
    [SerializeField] private MinigameManager minigameManager;

    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;

    [SerializeField] private Animator portraitAnimator;

    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;

    private Story currentStory;
    private bool dialogueIsPlaying;
    public bool isExitingLevel = false; // Flag to check if exiting the level

    private const string SPEAKER_TAG = "speaker";
    private const string PORTRAIT_TAG = "portrait";
    private const string LAYOUT_TAG = "layout";

    private const string MINIGAME_TAG = "minigame";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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
    
        // handle continuing to the next line in the dialogue when button is pressed
        if ( Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began )
        {
            if (IsTouchOverUI())
            {
                Debug.Log("Touch is on the Exit button, ignoring input for story continuation.");
                return;
            }

            Debug.Log("Touch detected, continuing story.");
            ContinueStory();
        }
    }

    private bool IsTouchOverUI()
    {
        PointerEventData pointerData = new PointerEventData(EventSystem.current)
        {
            position = Input.GetTouch(0).position
        };

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerData, results);

        foreach (RaycastResult result in results)
        {
            if (result.gameObject.name == "ExitButton") // Replace "ExitButton" with your button's name
            {
                Debug.Log("Touch is on the Exit button.");
                return true;
            }
        }

        return false;
    }

    public void EnterDialogueMode(TextAsset inkJSON) {
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);

        ContinueStory();
    }

    private void ExitDialogueMode()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
    }

    private void ContinueStory()
    {
        if(currentStory.canContinue)
        {
            // set text for the current dialogue line
            dialogueText.text = currentStory.Continue();

            // display choices, if any, for this dialogue line
            DisplayChoices();

            // handle tags
            HandleTags(currentStory.currentTags);
        }
        else
        {
            ExitDialogueMode();
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
                    break;
                case PORTRAIT_TAG:
                    portraitAnimator.Play(tagValue);
                    break;
                case LAYOUT_TAG:
                    break;
                case MINIGAME_TAG:
                    PlayMinigame(tagValue);
                    break;
                default:
                    Debug.LogWarning("Tag came in but is not currently being handled: " + tag);
                    break;
            }
        }
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
        foreach(Choice choice in currentChoices)
        {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
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
        Debug.Log("Choice made: " + choiceIndex);
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
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);
    }

    public void ExitLevel()
    {
        // Exit the level and return to the main menu
        isExitingLevel = true; // Set the flag to indicate exiting the level

        ExitDialogueMode(); // Ensure dialogue is exited when leaving the level
        SceneManager.LoadScene("Levels"); // Example: Load the main menu scene
    }
}
