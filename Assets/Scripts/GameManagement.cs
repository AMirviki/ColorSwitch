using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagement : MonoBehaviour
{
    public static GameManagement Instance;

    public GameObject startMessage;
    public GameObject gameOverPanel;
    public GameObject darkBackground;
    public CanvasGroup darkCanvasGroup;
    public TextMeshProUGUI finalScoreText;
    public bool isGameStarted = false;
    public bool isGameOver = false;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        Time.timeScale = 0f;
    }

    public void StartGame()
    {
        if (startMessage != null)
            StartCoroutine(FadeOutStartMessage());
        Time.timeScale = 1f;
    }

    IEnumerator FadeOutStartMessage()
    {
        CanvasGroup cg = startMessage.GetComponent<CanvasGroup>();
        if (cg == null)
            cg = startMessage.AddComponent<CanvasGroup>();

        float duration = 0.5f;
        float t = 0;

        while (t < duration)
        {
            t += Time.unscaledDeltaTime;
            cg.alpha = Mathf.Lerp(1f, 0f, t / duration);
            yield return null;
        }

        cg.alpha = 0f;
        startMessage.SetActive(false);
    }


    public void GameOver()
    {
        isGameOver = true;
        Time.timeScale = 0f;

        if (finalScoreText != null)
        {
            finalScoreText.text = "Best Score: " + Score.Instance.GetBestScore();
        }

        if (darkBackground != null)
            StartCoroutine(FadeInDarkBackground());

        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);

    }

    IEnumerator FadeInDarkBackground()
    {
        darkBackground.SetActive(true);
        darkCanvasGroup.alpha = 0f;

        float duration = 1f; 
        float t = 0;

        while (t < duration)
        {
            t += Time.unscaledDeltaTime;
            darkCanvasGroup.alpha = Mathf.Lerp(0f, 1f, t / duration);
            yield return null;
        }

        darkCanvasGroup.alpha = 1f;
    }


    public void Retry()
    {
        Score.Instance.ResetScore();
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
