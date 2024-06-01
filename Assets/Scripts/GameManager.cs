using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int totalScore;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void AddScore(int score)
    {
        totalScore += score;
        Debug.Log("Current Total Score: " + totalScore); // Debug log ekleyelim
    }


    public void ResetScore()
    {
        totalScore = 0;
        Debug.Log("Total Score Reset: " + totalScore); // Debug log ekleyelim
    }

    public int GetTotalScore()
    {
        return totalScore;
    }
}
