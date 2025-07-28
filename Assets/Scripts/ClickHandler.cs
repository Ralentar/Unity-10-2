using System;
using UnityEngine;

[RequireComponent(typeof(MouseClickDetector))]
[RequireComponent(typeof(Raycaster))]

public class ClickHandler : MonoBehaviour
{
    [SerializeField] private MouseClickDetector _mouseClickDetector;
    [SerializeField] private Raycaster _raycaster;

    public event Action<Cube> Click;

    private void Awake()
    {
        _mouseClickDetector = GetComponent<MouseClickDetector>();
        _raycaster = GetComponent<Raycaster>();
    }

    private void OnEnable()
    {
        _mouseClickDetector.LeftButtonClicked += OnLeftButtonClicked;
    }

    private void OnDisable()
    {
        _mouseClickDetector.LeftButtonClicked -= OnLeftButtonClicked;
    }

    private void OnLeftButtonClicked()
    {
        if (_raycaster.TryGetRaycastHitCollider(out Collider collider) == false)
            return;

        if (collider.TryGetComponent(out Cube cube))
            Click?.Invoke(cube);
    }
}