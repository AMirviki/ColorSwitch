using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetRandomColor_BackGround_Circle : MonoBehaviour
{

    private Image img;

    void Start()
    {
        img = GetComponent<Image>();
        SetRandomColor();
    }
    
    public void SetRandomColor()
    {
        int i = Random.Range(0, 4);
        switch (i)
        {
            case 0: img.color = new Color(1f, 0.07f, 0.49f, 0.2f); break;  
            case 1: img.color = new Color(0f, 0.82f, 0.9f, 0.2f); break;  
            case 2: img.color = new Color(1f, 1f, 0f, 0.2f); break;       
            case 3: img.color = new Color(0.6f, 0f, 1f, 0.2f); break;     
        }
    }
}
