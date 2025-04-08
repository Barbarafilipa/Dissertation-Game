using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsMenu : MonoBehaviour
{
    public void GoBack(){
        SceneManager.LoadSceneAsync("Main Menu");
    }

    public void OpenHouseLvl1() {
        SceneManager.LoadSceneAsync("Home - Lvl 1");
    }
}
