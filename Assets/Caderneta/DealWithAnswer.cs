using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DealWithAnswer : MonoBehaviour
{
    [SerializeField] private StickerData gameData;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Load the answer when the script starts
        LoadAnswer();
    }

    public void SaveAnswer()
    {
        // Get object name
        string objectName = gameObject.name;

        // Get input text
        string answer = GetComponent<TMP_InputField>().text;
        if (string.IsNullOrEmpty(answer))
        {
            //Debug.LogWarning("Answer is empty. Not saving.");
            return; // Do not save if the answer is empty
        }

        // Save the answer to StickerData
        gameData.SaveAnswer(objectName, answer);
        //Debug.Log($"Answer saved in StickerData for {objectName}: {answer}");
    }

    public void LoadAnswer()
    {
        // Get object name
        string objectName = gameObject.name;

        // Load the answer from StickerData
        string answer = gameData.GetAnswer(objectName);
        if (string.IsNullOrEmpty(answer))
        {
            //Debug.LogWarning($"No answer found for {objectName}. Setting input field to empty.");
            GetComponent<TMP_InputField>().text = ""; // Set to empty if no answer found
        }
        else
        {
            GetComponent<TMP_InputField>().text = answer; // Set the input field with the loaded answer
            //Debug.Log($"Loaded answer for {objectName}: {answer}");
        }
    }

}
