using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagement : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject darkBackground;
    public CanvasGroup darkCanvasGroup;
    public TextMeshProUGUI finalScoreText;

    public void GameOver()
    {
        Time.timeScale = 0f;

        if (finalScoreText != null)
        {
            finalScoreText.text = "Your Score: " + Score.Instance.GetScore();
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
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
