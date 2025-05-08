using UnityEngine;

public class EmojiSpawner : MonoBehaviour
{
    public Sprite[] emojiSprites; // Assign smile and sad emoji sprites
    public GameObject emojiPrefab; // Assign the prefab with the Image component
    public RectTransform spawnArea;   // The UI panel width you want to spawn within
    public float spawnInterval = 1.5f;
    public float minSpeed = 150f;
    public float maxSpeed = 300f;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            timer = 0f;
            SpawnEmoji();
        }
    }

    void SpawnEmoji()
    {
        float panelWidth = spawnArea.rect.width;
        float panelHeight = spawnArea.rect.height;

        float halfWidth = panelWidth * 0.5f;

        // Random horizontal position within the panel
        float spawnX = Random.Range(-halfWidth, halfWidth);

        // Y position at the top of the parent panel
        float spawnY = panelHeight * 0.5f;

        // Randomly select an emoji sprite and assign it to the prefab
        int randomIndex = Random.Range(0, emojiSprites.Length);
        emojiPrefab.GetComponent<UnityEngine.UI.Image>().sprite = emojiSprites[randomIndex];
        
        if(randomIndex < 5) // Assuming first 5 are happy emojis
        {
            emojiPrefab.GetComponent<EmojiFall>().emojiType = EmojiFall.EmojiType.Happy;
        }
        else
        {
            emojiPrefab.GetComponent<EmojiFall>().emojiType = EmojiFall.EmojiType.Sad;
        }

        GameObject emoji = Instantiate(emojiPrefab, spawnArea);

        RectTransform emojiRect = emoji.GetComponent<RectTransform>();
        emojiRect.anchoredPosition = new Vector2(spawnX, spawnY);

        EmojiFall fallScript = emoji.GetComponent<EmojiFall>();
        fallScript.fallSpeed = Random.Range(minSpeed, maxSpeed);
    }

}
