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
    public float rareColorChance = 1f;

    public int initialCount = 5;
    public int maxObstacleCount = 5;
    private List<GameObject> obstacles = new List<GameObject>();

    private bool spawnColorChanger = false;
    private float lastYSpanwer;

    public Transform player;
    public float spawnDistanceAhead = 10f;

    void Start()
    {
        lastYSpanwer = 4.63f;

        for (int i = 0; i < initialCount; i++)
        {
            spawnColorChanger = (i != initialCount - 1);
            SpawnNextAbsticle(spawnColorChanger);
        }
    }

    void Update() 
    {
        if (player != null && player.position.y + spawnDistanceAhead > lastYSpanwer)
        {
            spawnColorChanger = true;
            SpawnNextAbsticle(spawnColorChanger);
        }
    }

    public void SpawnNextAbsticle(bool spawnColorChanger = true)
    {
        GameObject obstacle = Instantiate(obsticlePrefab, new Vector3(0f, lastYSpanwer, obstacleZ), Quaternion.identity);

        obstacles.Add(obstacle);

        if (obstacles.Count > maxObstacleCount)
        {
            Destroy(obstacles[0]);
            obstacles.RemoveAt(0);
        }

        Transform rotator = obstacle.transform.Find("Rotator");

        Vector3 scoreTriggerPos = new Vector3(0f, lastYSpanwer + 0.5f, obstacleZ);
        Instantiate(scoreTriggerPrefab, scoreTriggerPos, Quaternion.identity);

        if (spawnColorChanger)
        {
            Instantiate(colorChangerPrefab, new Vector3(0f, lastYSpanwer + 5f + distanceBetween_Color, obstacleZ), Quaternion.identity);
        }

        if (Random.value < rareColorChance)
        {
            GameObject rare = Instantiate(colorChangerPrefab, Vector3.zero, Quaternion.identity);

            if (rotator != null)
            {
                rare.transform.SetParent(rotator);
                rare.transform.localPosition = new Vector3(0.56f, 0f, 0f);
            }
            else
            {
                rare.transform.SetParent(obstacle.transform);
                rare.transform.localPosition = new Vector3(0.56f, 0f, 0f);
            }
        }

        lastYSpanwer += distanceBetween;
    }
}
