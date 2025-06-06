using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Back_Botton : MonoBehaviour
{
  
    public void BackBtn()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
