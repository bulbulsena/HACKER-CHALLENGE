using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level2Controller : MonoBehaviour
{
    public Text problemText;
    public InputField answerInput;
    public Button submitButton;
    public Text feedbackText;
    public Text scoreText;
    public Text timeText;
    public Button continueButton;

    private int correctAnswer;
    private int score = 0;
    private float timeRemaining = 60f; // 1 dakika
    private System.Random random = new System.Random();
    private bool isGameActive = true;

    void Start()
    {
        StartGame();

    }

    void StartGame()
    {
        score = 0;
        timeRemaining = 60f;
        isGameActive = true;

        GenerateNewProblem();
        submitButton.onClick.AddListener(CheckAnswer);
        continueButton.onClick.AddListener(ContinueToMain);
        scoreText.text = "Puan: " + score;
        timeText.text = "S�re: " + timeRemaining.ToString("F2") + " s";
        feedbackText.text = ""; // Feedback textini s�f�rla
    }

    void Update()
    {
        if (isGameActive)
        {
            timeRemaining -= Time.deltaTime;
            timeText.text = "S�re: " + timeRemaining.ToString("F2") + " s";

            if (timeRemaining <= 0)
            {
                isGameActive = false;
                feedbackText.text = "S�re doldu! Toplam puan: " + score;
                submitButton.interactable = false;
            }
        }
    }

    void GenerateNewProblem()
    {
        int num1 = random.Next(1, 10);
        int num2 = random.Next(1, 10);
        string[] operations = { "+", "-", "*", "/" };
        string selectedOperation = operations[random.Next(operations.Length)];

        switch (selectedOperation)
        {
            case "+":
                correctAnswer = num1 + num2;
                problemText.text = num1 + " + " + num2 + " = ?";
                break;
            case "-":
                correctAnswer = num1 - num2;
                problemText.text = num1 + " - " + num2 + " = ?";
                break;
            case "*":
                correctAnswer = num1 * num2;
                problemText.text = num1 + " * " + num2 + " = ?";
                break;
            case "/":
                // E�er b�lme i�lemi se�ildiyse, num1'i num2'ye tam b�l�necek �ekilde ayarlayal�m
                num1 = num1 * num2; // num1'i num2'ye tam b�l�necek �ekilde ayarla
                correctAnswer = num1 / num2;
                problemText.text = num1 + " / " + num2 + " = ?";
                break;
        }
    }





    void CheckAnswer()
    {
        if (!isGameActive) return;

        int playerAnswer;
        if (int.TryParse(answerInput.text, out playerAnswer))
        {
            if (playerAnswer == correctAnswer)
            {
                feedbackText.text = "Do�ru!";
                score += 10;
                scoreText.text = "Puan: " + score;
            }
            else
            {
                feedbackText.text = "Yanl��, do�ru cevap: " + correctAnswer;
            }
            GenerateNewProblem();
            answerInput.text = "";
        }
        else
        {
            feedbackText.text = "Ge�erli bir tamsay� girin.";
        }
    }
    
    void ContinueToMain()
    {
        GameManager.instance.AddScore(score); // Level 2'de kazan�lan puan� GameManager'a ekle
        SceneManager.LoadScene("oyun_main"); // oyun_main sahnesine ge�i�
    }

}

