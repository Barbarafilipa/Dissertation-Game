using UnityEngine;
using UnityEngine.UI;

public class StarClick : MonoBehaviour
{
    public enum StarType { Happy, Sad }
    public StarType starType;
    public void OnClick()
    {
        Debug.Log("Star clicked!");
        // Add to score here if needed
        Destroy(gameObject);

        GameManagerEstrelas.Instance.CaughtStar(this);
    }
}
