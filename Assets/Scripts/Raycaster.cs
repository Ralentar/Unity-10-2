using UnityEngine;

public class Raycaster : MonoBehaviour
{
    [SerializeField] private float _maxDistance = 50;

    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }

    public bool TryGetRaycastHitCollider(out Collider hitCollider)
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        bool isHit = Physics.Raycast(ray, out RaycastHit hit, _maxDistance);
        hitCollider = hit.collider;

        return isHit;
    }
}