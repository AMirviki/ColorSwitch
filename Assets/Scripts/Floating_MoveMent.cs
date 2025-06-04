using UnityEngine;
using UnityEngine.UI;

public class Floating_MoveMent : MonoBehaviour
{
    public float amplitude = 20f;
    public float speed = 0.5f;
    private Vector3 startPos;

    private Image img;

    void Start()
    {
        startPos = transform.localPosition;
        img = GetComponent<Image>();
        SetRandomColor();
    }

    void Update()
    {
        float y = Mathf.Sin(Time.time * speed) * amplitude;
        transform.localPosition = startPos + new Vector3(0, y, 0);
    }

    void SetRandomColor()
    {
        int i = Random.Range(0, 4);
        switch (i)
        {
            case 0:
                gameObject.tag = "Pink";
                img.color = new Color(1f, 0.07f, 0.49f, 0.2f);
                break;
            case 1:
                gameObject.tag = "Blue";
                img.color = new Color(0f, 0.82f, 0.9f, 0.2f);
                break;
            case 2:
                gameObject.tag = "Yellow";
                img.color = new Color(1f, 0.92f, 0.016f, 0.2f);
                break;
            case 3:
                gameObject.tag = "Purple";
                img.color = new Color(0.6f, 0f, 1f, 0.2f);
                break;
        }
        Debug.Log("Color Was Selected : " + gameObject.tag);
    }
}
