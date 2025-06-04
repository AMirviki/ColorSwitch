using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTriggers : MonoBehaviour
{
    private bool isTriggered = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isTriggered && collision.CompareTag("Player"))
        {
            isTriggered = true;
            Score.Instance.AddScore(1);
        }
    }
}
