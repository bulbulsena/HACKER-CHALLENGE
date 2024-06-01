using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    public Text playerScoreText;

    void Start()
    {
        if (GameManager.instance != null)
        {
            playerScoreText.text = "Puan: " + GameManager.instance.GetTotalScore().ToString();
        }
        else
        {
            playerScoreText.text = "Puan: 0";
        }
    }
}
