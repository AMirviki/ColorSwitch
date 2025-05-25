using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow_Player : MonoBehaviour
{
    public Transform player;
    public float offsetY = 2f;

     void LateUpdate()
    {
        if(player!=null)
        {
            Vector3 newPos = transform.position;
            if(player.position.y > transform.position.y - offsetY)
            {
                newPos.y = player.position.y + offsetY;
                transform.position = newPos;
            }
        }
    }
}
