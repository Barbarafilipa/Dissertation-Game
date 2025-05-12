using UnityEngine;
using UnityEngine.UI;

public class ScoreManagerEstrelas : MonoBehaviour
{
    public static ScoreManagerEstrelas Instance;

    [SerializeField] private Slider scoreSlider;
    [SerializeField] private Image fillImage; // Reference to the fill image of the slider
    [SerializeField] private GameObject[] frogs;
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
        // Add score, ensuring curentScore doesn't go below 0
        currentScore += amount;
        currentScore = Mathf.Clamp(currentScore, 0, maxScore);
        scoreSlider.value = Mathf.Clamp(currentScore, scoreSlider.minValue, scoreSlider.maxValue);
        
        UpdateSlider();
    }

    private void UpdateSlider()
    {
        // Update the fill color based on the score
        if (currentScore > 7)
        {
            fillImage.color = Color.green; // Change to green when max score is reached
            frogs[0].SetActive(false);
            frogs[1].SetActive(false);
            frogs[2].SetActive(true);
        }
        else if (currentScore < 4)
        {
            fillImage.color = Color.red; // Change to red when score is negative
            frogs[0].SetActive(true);
            frogs[1].SetActive(false);
            frogs[2].SetActive(false);
        }
        else
        {
            fillImage.color = Color.yellow; // Default color for normal scores
            frogs[0].SetActive(false);
            frogs[1].SetActive(true);
            frogs[2].SetActive(false);
        }
    }
}
