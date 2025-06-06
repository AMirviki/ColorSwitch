using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager_Start_Scene : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("SceneLevel_1");
    }
    public void Credits()
    {
        SceneManager.LoadScene("Scene_Credits");
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}
