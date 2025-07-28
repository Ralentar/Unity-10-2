using UnityEngine;

[RequireComponent(typeof(ClickHandler))]
[RequireComponent(typeof(Spawner))]
[RequireComponent(typeof(Exploder))]
[RequireComponent(typeof(Destroyer))]

public class EventHandler : MonoBehaviour
{
    [SerializeField] private ClickHandler _clickHandler;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Exploder _exploder;
    [SerializeField] private Destroyer _destroyer;

    private void Awake()
    {
        _clickHandler = GetComponent<ClickHandler>();
        _spawner = GetComponent<Spawner>();
        _exploder = GetComponent<Exploder>();
        _destroyer = GetComponent<Destroyer>();
    }

    private void OnEnable()
    {
        _clickHandler.Click += ProcessEvent;
    }

    private void OnDisable()
    {
        _clickHandler.Click -= ProcessEvent;
    }

    private void ProcessEvent(Cube cube)
    {
        float minValue = 0;
        float maxValue = 100;
        float segmentationChance = Random.Range(minValue, maxValue);

        if (segmentationChance <= cube.SegmentationThreshold)
        {
            Rigidbody[] cubes = _spawner.SpawnCubes(cube.transform);
            _exploder.Explode(cubes, cube.transform);
        }
        else
        {
            _exploder.Explode(cube.transform);
        }

        _destroyer.Destroy(cube);
    }
}