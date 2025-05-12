using UnityEngine;

public class GameManagerEstrelas : MonoBehaviour
{
    public static GameManagerEstrelas Instance;
    [SerializeField] private MinigameManager minigameManager;
    [SerializeField] private Animator sliderAnimator;

    void Awake()
    {
        Instance = this;
    }

    public void CaughtStar(StarClick star)
    {
        // Logic to handle when a star is caught
        Debug.Log("Star caught: " + star.starType);
        ScoreManagerEstrelas.Instance.AddScore(star.starType == StarClick.StarType.Happy ? 1 : -1);
        // Play animation
        sliderAnimator.Play(star.starType == StarClick.StarType.Happy ? "caught_happy" : "caught_sad");

        // Check if all stars are collected
        if (ScoreManagerEstrelas.Instance.currentScore >= ScoreManagerEstrelas.Instance.maxScore)
        {
            AllStarsCollected();
        }
    }

    public void AllStarsCollected()
    {
        // Wait for a second before ending the game
        Invoke("CompleteMinigame", 1f);
    }

    public void CompleteMinigame()
    {
        // Logic to complete the minigame
        Debug.Log("Minigame completed!");
        minigameManager.CompleteMinigame();
    }
}
