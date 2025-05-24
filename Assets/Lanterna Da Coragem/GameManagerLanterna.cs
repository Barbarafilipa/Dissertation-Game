using UnityEngine;

public class GameManagerLanterna : MonoBehaviour
{
    public static GameManagerLanterna Instance;
    private int remainingMonsters = 4;
    [SerializeField] private MinigameManager minigameManager;

    void Awake()
    {
        Instance = this;
    }

    public void RegisterMonster()
    {
        remainingMonsters++;
    }

    public void MonsterRevealed()
    {
        remainingMonsters--;

        if (remainingMonsters <= 0)
        {
            // Wait for a second before ending the game
            Invoke("EndGame", 2f);
        }
    }

    void EndGame()
    {
        //Debug.Log("You were brave! Game Over!");
        minigameManager.CompleteMinigame();
    }
}
