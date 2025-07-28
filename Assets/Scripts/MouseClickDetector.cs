using System;
using UnityEngine;

public class MouseClickDetector : MonoBehaviour
{
    public event Action LeftButtonClicked;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            LeftButtonClicked?.Invoke();
    }
}