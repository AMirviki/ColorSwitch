using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    public float scrollSpeed = 0.1f;
    public Transform cam;

    void Update()
    {
            float offsetY = cam.position.y * scrollSpeed;
    }
}
