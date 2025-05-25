using UnityEngine;

public class TrailColorTest : MonoBehaviour
{
    public Color testColor = Color.green;

    void Start()
    {
        TrailRenderer trail = GetComponent<TrailRenderer>();
        if (trail != null)
        {
            Gradient grad = new Gradient();
            grad.SetKeys(
                new GradientColorKey[] {
                    new GradientColorKey(testColor, 0f),
                    new GradientColorKey(new Color(testColor.r, testColor.g, testColor.b, 0f), 1f)
                },
                new GradientAlphaKey[] {
                    new GradientAlphaKey(1f, 0f),
                    new GradientAlphaKey(0f, 1f)
                }
            );
            trail.colorGradient = grad;
        }
    }
}
