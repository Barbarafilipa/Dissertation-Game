using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [System.Serializable]
    public class NamedAudio
    {
        public string name;
        public AudioClip clip;
    }

    public List<NamedAudio> audioClips;
    private Dictionary<string, AudioClip> clipDictionary;

    private AudioSource audioSource;

    private void Awake()
    {
        // Singleton pattern
        if (Instance == null)
        {
            Instance = this;
            Initialize();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Initialize()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        clipDictionary = new Dictionary<string, AudioClip>();

        foreach (var entry in audioClips)
        {
            if (!clipDictionary.ContainsKey(entry.name))
            {
                clipDictionary.Add(entry.name, entry.clip);
            }
        }
    }

    public void PlayAudio(string clipName)
    {
        if (clipDictionary.TryGetValue(clipName, out AudioClip clip))
        {
            audioSource.PlayOneShot(clip);
            Debug.Log($"Playing audio: {clipName}");
        }
        else
        {
            Debug.LogWarning($"Audio clip with name '{clipName}' not found.");
        }
    }

    public void StopAudio()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
            Debug.Log("Audio stopped.");
        }
    }
}
