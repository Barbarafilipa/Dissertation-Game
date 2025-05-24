using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsMenu : MonoBehaviour
{
    [SerializeField] private GameObject confettis;
    [SerializeField] private GameObject finalMessage;

    private void Start()
    {
        // Check if all levels are completed and trigger the final animation if so
        CheckGameCompletion();
    }

    public void GoBack()
    {
        SceneManager.LoadSceneAsync("Main Menu");
    }

    public void OpenHouseLvl1()
    {
        SceneManager.LoadSceneAsync("Home - Lvl 1");
    }
    public void OpenHouseLvl2()
    {
        SceneManager.LoadSceneAsync("Home - Lvl 2");
    }
    public void OpenHouseLvl3()
    {
        SceneManager.LoadSceneAsync("Home - Lvl 3");
    }
    public void OpenHouseLvl4()
    {
        SceneManager.LoadSceneAsync("Home - Lvl 4");
    }
    public void OpenHouseLvl5()
    {
        SceneManager.LoadSceneAsync("Home - Lvl 5");
    }
    public void OpenHouseLvl6()
    {
        SceneManager.LoadSceneAsync("Home - Lvl 6");
    }

    private void CheckGameCompletion()
    {
        // Check if all levels are completed
        for (int i = 1; i <= 6; i++)
        {
            if (!PlayerPrefs.HasKey($"Level_{i}") || PlayerPrefs.GetInt($"Level_{i}") == 0)
            {
                return; // If any level is not completed, exit the method
            }
        }

        // If all levels are completed, trigger the final animation
        if (!PlayerPrefs.HasKey("GameCompleted") || PlayerPrefs.GetInt("GameCompleted") == 0)
        {
            PlayerPrefs.SetInt("GameCompleted", 1);
            PlayerPrefs.Save();

            // Trigger your final animation here
            confettis.SetActive(true);
            StartCoroutine(ShowFinalMessage());
        }
    }

    private IEnumerator ShowFinalMessage()
    {
        finalMessage.SetActive(true);
        yield return new WaitForSeconds(5f);
        finalMessage.SetActive(false);
    }
}
