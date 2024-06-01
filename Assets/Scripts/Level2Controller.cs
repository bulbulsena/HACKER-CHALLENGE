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
        timeText.text = "Süre: " + timeRemaining.ToString("F2") + " s";
        feedbackText.text = ""; // Feedback textini sýfýrla
    }

    void Update()
    {
        if (isGameActive)
        {
            timeRemaining -= Time.deltaTime;
            timeText.text = "Süre: " + timeRemaining.ToString("F2") + " s";

            if (timeRemaining <= 0)
            {
                isGameActive = false;
                feedbackText.text = "Süre doldu! Toplam puan: " + score;
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
                // Eðer bölme iþlemi seçildiyse, num1'i num2'ye tam bölünecek þekilde ayarlayalým
                num1 = num1 * num2; // num1'i num2'ye tam bölünecek þekilde ayarla
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
                feedbackText.text = "Doðru!";
                score += 10;
                scoreText.text = "Puan: " + score;
            }
            else
            {
                feedbackText.text = "Yanlýþ, doðru cevap: " + correctAnswer;
            }
            GenerateNewProblem();
            answerInput.text = "";
        }
        else
        {
            feedbackText.text = "Geçerli bir tamsayý girin.";
        }
    }
    
    void ContinueToMain()
    {
        GameManager.instance.AddScore(score); // Level 2'de kazanýlan puaný GameManager'a ekle
        SceneManager.LoadScene("oyun_main"); // oyun_main sahnesine geçiþ
    }

}

