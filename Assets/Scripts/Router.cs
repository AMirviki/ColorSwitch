using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Router : MonoBehaviour
{
    [Header("Rotation Settings")]
    public float minSpeed = 50f;
    public float maxSpeed = 120f;

    public bool randomizeRotation = true;
    public float rotationSpeed;



    void Start()
    {
        if (randomizeRotation)
        {
            rotationSpeed = Random.Range(minSpeed, maxSpeed);

            if (Random.value < 0.5f)
                rotationSpeed *= -1f;
        }
    }

    void Update()
    {
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }
}
