using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColor : MonoBehaviour
{
    public string CurrentColor;
    private SpriteRenderer sr;
    [SerializeField] private TrailRenderer trail;
    public GameObject colorChangeFXPrefab;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        SetRandomColor();
    }

    public void SetRandomColor()
    {
        int i = Random.Range(0, 4);
        switch (i)
        {
            case 0: CurrentColor = "Pink"; sr.color = new Color(1f, 0.07f, 0.49f); break;
            case 1: CurrentColor = "Blue"; sr.color = new Color(0f, 0.82f, 0.9f); break;
            case 2: CurrentColor = "Yellow"; sr.color = Color.yellow; break;
            case 3: CurrentColor = "Purple"; sr.color = new Color(0.6f, 0f, 1f); break;
        }

        if (trail != null && sr != null)
        {
            Gradient gradient = new Gradient();

            gradient.SetKeys(
                new GradientColorKey[] {
                new GradientColorKey(sr.color, 0f),
                new GradientColorKey(new Color(sr.color.r, sr.color.g, sr.color.b, 0f), 1f)
                },
                new GradientAlphaKey[] {
                new GradientAlphaKey(1f, 0f),
                new GradientAlphaKey(0f, 1f)
                }
            );

            trail.colorGradient = gradient;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "ColorChanger")
        {
            SetRandomColor();

            if (colorChangeFXPrefab != null)
            {
                GameObject fx = Instantiate(colorChangeFXPrefab, transform.position, Quaternion.identity);
                fx.GetComponent<SpriteRenderer>().color = sr.color;
                Destroy(fx, 2f);
            }

            Destroy(collision.gameObject);
            return;
        }

        if (collision.tag == "Score")
        {
            return;
        }

        if (collision.tag != CurrentColor && collision.tag != "Ignore")
        {
            FindObjectOfType<GameManagement>().GameOver();
        }
    }
}