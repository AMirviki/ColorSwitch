using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public static Score Instance;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI bestScoreText;

    private int score = 0;
    private int bestScore = 0;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        LoadScore();  
        score = 0;     
        UpdateUI();    
    }

    public void AddScore(int amount)
    {
        score += amount;

        if (score > bestScore)
        {
            bestScore = score;
            SaveScore(); 
        }

        UpdateUI();
    }
    public int GetBestScore() => bestScore;
    public int GetScore() => score;

    private void UpdateUI()
    {
        if (scoreText != null)
            scoreText.text = " " + score.ToString();

        if (bestScoreText != null)
            bestScoreText.text = "Best Score: " + bestScore.ToString();
    }

    private void SaveScore()
    {
        SaveData data = new SaveData
        {
            bestScore = bestScore
        };

        SaveManager.Save(data);
    }

    private void LoadScore()
    {
        SaveData data = SaveManager.Load();
        bestScore = data.bestScore;
    }

    public void ResetScore()
    {
        score = 0;
        UpdateUI();
    }
}
