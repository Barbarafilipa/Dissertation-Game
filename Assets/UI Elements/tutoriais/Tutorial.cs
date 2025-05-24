using System;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject hand;
    private Boolean clickTutorialAlreadyShown = false;
    private Boolean escolherTutorialAlreadyShown = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowClickTutorial()
    {
        Debug.Log("ShowClickTutorial called");
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Home - Lvl 1" && !clickTutorialAlreadyShown)
        {
            // Show the tutorial
            Debug.Log("Showing click tutorial");

            hand.SetActive(true);
            clickTutorialAlreadyShown = true;
        }
    }
    
    public void ShowEscolherTutorial()
    {
        Debug.Log("ShowEscolherTutorial called");
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Home - Lvl 1" && !escolherTutorialAlreadyShown)
        {
            // Show the tutorial
            Debug.Log("Showing tutorial");

            hand.SetActive(true);
            hand.GetComponent<Animator>().Play("Escolher Tutorial");
            escolherTutorialAlreadyShown = true;
        }
    }
}
