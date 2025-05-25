using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractSpawner : MonoBehaviour
{
    public GameObject obsticlePrefab;
    public GameObject colorChangerPrefab;
    public float distanceBetween = 4f;
    public float distanceBetween_Color = 4f;
    public int initialCount = 5;
    private bool spawnColorChanger = false;
    private float lastY;

    void Start()
    {
        lastY = 4.63f;
        
        for (int i = 0; i < initialCount; i++)
        {
            spawnColorChanger = (i != initialCount - 1);

            SpawnNextAbsticle(spawnColorChanger);
        }
    }


    public void SpawnNextAbsticle(bool spawnColorChanger = true)
    {
        Instantiate(obsticlePrefab, new Vector3(0f, lastY, 0f), Quaternion.identity);

        if (spawnColorChanger)
        {
            Instantiate(colorChangerPrefab, new Vector3(0f, lastY + 5f + distanceBetween_Color, 0f), Quaternion.identity);
        }

        lastY += distanceBetween;
    }
}
