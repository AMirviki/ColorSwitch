using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractSpawner : MonoBehaviour
{
    public GameObject obsticlePrefab;
    public GameObject colorChangerPrefab;
    public GameObject scoreTriggerPrefab;
    public float obstacleZ = 5f;
    public float distanceBetween = 4f;
    public float distanceBetween_Color = 4f;
    [Range(0f, 1f)]
    public float rareColorChance =1f;
    public int initialCount = 5;
    private bool spawnColorChanger = false;
    private float distanceBetween_Color_Chance = 0f;
    private float lastYSpanwer;
    
    void Start()
    {
        lastYSpanwer = 4.63f;
        
        for (int i = 0; i < initialCount; i++)
        {
            spawnColorChanger = (i != initialCount - 1);

            SpawnNextAbsticle(spawnColorChanger);
        }
    }


    public void SpawnNextAbsticle(bool spawnColorChanger = true)
    {
        GameObject obstacle = Instantiate(obsticlePrefab, new Vector3(0f, lastYSpanwer, obstacleZ), Quaternion.identity);

        Vector3 scoreTriggerPos = new Vector3(0f, lastYSpanwer + 0.5f, obstacleZ);
        Instantiate(scoreTriggerPrefab, scoreTriggerPos, Quaternion.identity);

        if (spawnColorChanger)
        {
            Instantiate(colorChangerPrefab, new Vector3(0f, lastYSpanwer + 5f + distanceBetween_Color, obstacleZ), Quaternion.identity);
        }

        if (Random.value < rareColorChance)
        {
            GameObject rare = Instantiate(colorChangerPrefab, Vector3.zero, Quaternion.identity);
            rare.transform.SetParent(obsticlePrefab.transform);
            rare.transform.localPosition = new Vector3(0f, lastYSpanwer + distanceBetween_Color_Chance, 0f);
        }

        lastYSpanwer += distanceBetween;
    }

}
