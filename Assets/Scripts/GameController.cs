using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Image imageDisplay;
    public Sprite[] images;
    public Text scoreText;
    public Text timeText;
    public Button sameButton;
    public Button differentButton;
    public Button continueButton;

    private int score = 0;
    private float timeRemaining = 30f;
    private Sprite previousImage;
    private Sprite currentImage;
    private System.Random random = new System.Random();

    void Start()
    {
        sameButton.onClick.AddListener(() => CheckAnswer(true));
        differentButton.onClick.AddListener(() => CheckAnswer(false));
        continueButton.onClick.AddListener(ContinueToNextLevel);
        continueButton.gameObject.SetActive(false);
        DisplayNewImage();
    }

    void Update()
    {
        timeRemaining -= Time.deltaTime;
        timeText.text = "Zaman: " + Mathf.Ceil(timeRemaining).ToString();

        if (timeRemaining <= 0)
        {
            EndGame();
        }
    }

    void DisplayNewImage()
    {
        previousImage = currentImage;

        if (previousImage != null && random.Next(0, 100) < 50)
        {
            currentImage = previousImage;
        }
        else
        {
            currentImage = images[Random.Range(0, images.Length)];
        }

        imageDisplay.sprite = currentImage;
    }

    void CheckAnswer(bool isSame)
    {
        bool correctAnswer = (currentImage == previousImage) == isSame;

        if (correctAnswer)
        {
            score += 10;
            scoreText.text = "Puan: " + score.ToString();
        }
        else
        {
            score -= 5;
            scoreText.text = "Puan: " + score.ToString();
        }

        DisplayNewImage();
    }

    void EndGame()
    {
        sameButton.interactable = false;
        differentButton.interactable = false;
        timeText.text = "Süre Bitti!";
        GameManager.instance.AddScore(score);
        continueButton.gameObject.SetActive(true);


        // Oyunun tamamlanmasýndan sonra puaný sýfýrla
        score = 0;
    }

    void ContinueToNextLevel()
    {
        SceneManager.LoadScene("oyun_main");
    }
}
