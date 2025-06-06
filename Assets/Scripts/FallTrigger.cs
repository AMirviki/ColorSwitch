using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallTrigger : MonoBehaviour
{
    public Transform player;
    public float yOffset = -10f;
    public float highestPlayerY = 0f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            GameManagement.Instance.GameOver();
        }
    }

    void Start()
    {
        if (player != null)
        {
            highestPlayerY = player.position.y;
            Vector3 pos = transform.position;
            pos.y = player.position.y + yOffset;
            transform.position = pos;
        }
    }

    private void Update()
    {
        if (player != null)
        {
            if(player.position.y > highestPlayerY)
            {
                highestPlayerY = player.position.y;
                Vector3 pos = transform.position;
                pos.y = player.position.y + yOffset;
                transform.position = pos;
            }
        }
    }
}
