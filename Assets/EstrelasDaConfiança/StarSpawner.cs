using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class StarSpawner : MonoBehaviour
{
    public GameObject starPrefab;
    public RectTransform spawnArea;
    public float spawnInterval = 1f;
    public float starLifetime = 5f;
    [SerializeField] private Sprite[] starPrefabs;

    private void Start()
    {
        StartCoroutine(SpawnStars());
    }

    IEnumerator SpawnStars()
    {
        while (true)
        {
            SpawnStar();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnStar()
    {
        // Choose a random prefab
        int randomIndex = Random.Range(0, starPrefabs.Length);
        Sprite imageToSpawn = starPrefabs[randomIndex];
        starPrefab.GetComponent<Image>().sprite = imageToSpawn;

        if(randomIndex < 5) // Assuming first 5 are happy stars
        {
            starPrefab.GetComponent<StarClick>().starType = StarClick.StarType.Happy;
        }
        else
        {
            starPrefab.GetComponent<StarClick>().starType = StarClick.StarType.Sad;
        }

        // Random position inside the panel
        Vector2 randomPos = new Vector2(
            Random.Range(0, spawnArea.rect.width),
            Random.Range(0, spawnArea.rect.height)
        );

        GameObject star = Instantiate(starPrefab, spawnArea);
        RectTransform starRect = star.GetComponent<RectTransform>();

        // Adjust for pivot (assuming default pivot is 0.5, 0.5)
        randomPos -= spawnArea.rect.size / 2f;

        starRect.anchoredPosition = randomPos;

        // Auto destroy
        Destroy(star, starLifetime);
    }
}
