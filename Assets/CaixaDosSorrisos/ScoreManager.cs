using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    [SerializeField] private Slider scoreSlider;
    [SerializeField] private Image fillImage; // Reference to the fill image of the slider

    public int currentScore = 0;
    public int maxScore = 10;

    private void Awake()
    {
        // Singleton pattern
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        scoreSlider.value = currentScore;
    }

    public void AddScore(int amount)
    {
        currentScore += amount;
        scoreSlider.value = Mathf.Clamp(currentScore, scoreSlider.minValue, scoreSlider.maxValue);
        UpdateSlider();

        // Check if the score is at max
        if (currentScore >= maxScore)
        {
            // Trigger the end of the minigame
            GameManagerCaixaSorrisos.Instance.AllEmotionsCollected();
        }
    }

    private void UpdateSlider()
    {
        // Update the fill color based on the score
        if (currentScore > 6)
        {
            fillImage.color = Color.green; // Change to green when max score is reached
        }
        else if (currentScore < 3)
        {
            fillImage.color = Color.red; // Change to red when score is negative
        }
        else
        {
            fillImage.color = Color.yellow; // Default color for normal scores
        }
    }
}
