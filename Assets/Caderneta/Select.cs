using UnityEngine;
using UnityEngine.UI;

public class Select : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetButton();
    }

    private void SetButton()
    {
        // Get child object
        GameObject child = transform.GetChild(0).gameObject;
        Button button = gameObject.GetComponent<Button>();
        GameObject parent = gameObject.transform.parent.gameObject;

        if (child != null)
        {
            button.onClick.AddListener(() =>
            {
                // Handle button click
                if (child.activeSelf)
                {
                    child.SetActive(false);
                    parent.GetComponent<HandleChoice>().RemoveAnswer(gameObject.name);
                }
                else
                {
                    child.SetActive(true);
                    parent.GetComponent<HandleChoice>().AddAnswer(gameObject.name);
                }
            });

        }
    }
}
