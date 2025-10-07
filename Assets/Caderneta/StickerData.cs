using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StickerData", menuName = "Game/StickerData")]
public class StickerData : ScriptableObject
{
    public List<string> collectedStickers = new List<string>();
    public List<string> placedStickers = new List<string>();
    public List<QuestionAnswerPair> savedAnswers = new List<QuestionAnswerPair>();
    public List<MultiAnswerPair> multiAnswers = new List<MultiAnswerPair>();



    private const string SaveKey = "StickerSaveData";

    public void AddSticker(string sticker)
    {
        if (!collectedStickers.Contains(sticker))
        {
            collectedStickers.Add(sticker);
            SaveStickers(); // Save immediately after adding
            Debug.Log("STICKER DATA - Sticker added: " + sticker);
        }
    }

    public void PlaceSticker(string sticker)
    {
        if (!placedStickers.Contains(sticker))
        {
            placedStickers.Add(sticker);
            collectedStickers.Remove(sticker); // Remove from collected list
            SaveStickers();
            Debug.Log("STICKER DATA - Sticker placed: " + sticker);
        }
    }

    public List<string> GetCollectedStickers()
    {
        return new List<string>(collectedStickers);
    }

    public List<string> GetPlacedStickers()
    {
        return new List<string>(placedStickers);
    }

    public void SaveStickers()
    {
        StickerSaveWrapper wrapper = new StickerSaveWrapper
        {
            collected = collectedStickers,
            placed = placedStickers,
            answers = savedAnswers,
            multiAnswers = multiAnswers
        };

        string json = JsonUtility.ToJson(wrapper);
        PlayerPrefs.SetString(SaveKey, json);
        PlayerPrefs.Save();
    }

    public void LoadStickers()
    {
        if (PlayerPrefs.HasKey(SaveKey))
        {
            string json = PlayerPrefs.GetString(SaveKey);
            StickerSaveWrapper wrapper = JsonUtility.FromJson<StickerSaveWrapper>(json);
            collectedStickers = wrapper.collected ?? new List<string>();
            placedStickers = wrapper.placed ?? new List<string>();
            savedAnswers = wrapper.answers ?? new List<QuestionAnswerPair>();
            multiAnswers = wrapper.multiAnswers ?? new List<MultiAnswerPair>();
            Debug.Log("STICKER DATA - Stickers loaded from PlayerPrefs.");
        }
    }

    public void SaveAnswer(string questionId, string answer)
    {
        var existing = savedAnswers.Find(q => q.questionId == questionId);
        if (existing != null)
        {
            existing.answer = answer;
        }
        else
        {
            savedAnswers.Add(new QuestionAnswerPair { questionId = questionId, answer = answer });
        }
        SaveStickers();
    }

    public string GetAnswer(string questionId)
    {
        var existing = savedAnswers.Find(q => q.questionId == questionId);
        return existing != null ? existing.answer : "";
    }

    public void SaveMultipleChoice(string questionId, List<string> selectedAnswers)
    {
        var existing = multiAnswers.Find(q => q.questionId == questionId);
        if (existing != null)
        {
            existing.selectedAnswers = new List<string>(selectedAnswers);
        }
        else
        {
            multiAnswers.Add(new MultiAnswerPair { questionId = questionId, selectedAnswers = new List<string>(selectedAnswers) });
        }
        SaveStickers();
    }

    public List<string> GetMultipleChoice(string questionId)
    {
        var existing = multiAnswers.Find(q => q.questionId == questionId);
        return existing != null ? new List<string>(existing.selectedAnswers) : new List<string>();
    }

    [System.Serializable]
    public class QuestionAnswerPair
    {
        public string questionId;
        public string answer;
    }

    [System.Serializable]
    public class MultiAnswerPair
    {
        public string questionId;
        public List<string> selectedAnswers = new List<string>();
    }

    [System.Serializable]
    private class StickerSaveWrapper
    {
        public List<string> collected;
        public List<string> placed;
        public List<QuestionAnswerPair> answers;
        public List<MultiAnswerPair> multiAnswers;
    }
}
