using System.Collections.Generic;
using UnityEngine;

public class HandleChoice : MonoBehaviour
{
    private List<string> selectedAnswers;
    [SerializeField] private StickerData gameData;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Load the selected answers when the script starts
        LoadChoice();
    }

    public void SaveChoice()
    {
        // Get object name
        string objectName = gameObject.name;

        if (selectedAnswers == null || selectedAnswers.Count == 0)
        {
            //Debug.LogWarning("No answers selected. Not saving.");
            return; // Do not save if no answers are selected
        }

        // Save the selected answers to StickerData
        gameData.SaveMultipleChoice(objectName, selectedAnswers);
        //Debug.Log($"Multiple choice answers saved in StickerData for {objectName}: {string.Join(", ", selectedAnswers)}");
    }

    public void LoadChoice()
    {
        // Get object name
        string objectName = gameObject.name;

        // Load the selected answers from StickerData
        selectedAnswers = gameData.GetMultipleChoice(objectName);
        if (selectedAnswers == null || selectedAnswers.Count == 0)
        {
            //Debug.LogWarning($"No answers found for {objectName}. Setting selection to empty.");
            selectedAnswers = new List<string>(); // Set to empty if no answers found
        }
        else
        {
            Debug.Log($"Loaded multiple choice answers for {objectName}: {string.Join(", ", selectedAnswers)}");
        }

        foreach (string answer in selectedAnswers)
        {            
            Transform answerTransform = transform.Find(answer);
            if (answerTransform != null)
            {
                // Set child object of answerTransform as active
                answerTransform.GetChild(0).gameObject.SetActive(true);
                //Debug.Log($"Answer '{answer}' found and marked as selected.");
            }
            else
            {
                Debug.LogWarning($"Answer '{answer}' not found in children of {objectName}.");
            }
        }
    }

    public void AddAnswer(string answer)
    {
        if (selectedAnswers == null)
        {
            selectedAnswers = new List<string>();
        }

        if (!selectedAnswers.Contains(answer))
        {
            selectedAnswers.Add(answer);
            //Debug.Log($"Answer added: {answer}");
            SaveChoice(); // Save the choice after adding an answer
        }
        else
        {
            Debug.LogWarning($"Answer '{answer}' is already selected.");
        }
    }

    public void RemoveAnswer(string answer)
    {
        if (selectedAnswers != null && selectedAnswers.Contains(answer))
        {
            selectedAnswers.Remove(answer);
            //Debug.Log($"Answer removed: {answer}");
            SaveChoice(); // Save the choice after removing an answer
        }
        else
        {
            Debug.LogWarning($"Answer '{answer}' not found in selected answers.");
        }
    }
}
