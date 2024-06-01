using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class level3Controller : MonoBehaviour
{
    


    private int correctAnswer;
    private int score = 0;

    void ContinueToMain()
    {
        GameManager.instance.AddScore(score); // Level 2'de kazanýlan puaný GameManager'a ekle
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
