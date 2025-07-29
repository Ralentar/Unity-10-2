using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Renderer))]

public class Cube : MonoBehaviour
{
    public float SegmentationThreshold { get; private set; } = 100;

    private void Start()
    {
        if (GetComponent<Renderer>().material != null)
            Recolor(Random.ColorHSV());
    }

    public void SetSegmentationThreshold(float chance)
    {
        SegmentationThreshold = chance;
    }

    private void Recolor(Color color)
    {
        GetComponent<Renderer>().material.color = color;
    }
}