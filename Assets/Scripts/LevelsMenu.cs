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
    public void OpenHouseLvl2() {
        SceneManager.LoadSceneAsync("Home - Lvl 2");
    }
    public void OpenHouseLvl3() {
        SceneManager.LoadSceneAsync("Home - Lvl 3");
    }
    public void OpenHouseLvl4() {
        SceneManager.LoadSceneAsync("Home - Lvl 4");
    }
    public void OpenHouseLvl5() {
        SceneManager.LoadSceneAsync("Home - Lvl 5");
    }
    public void OpenHouseLvl6() {
        SceneManager.LoadSceneAsync("Home - Lvl 6");
    }

}
