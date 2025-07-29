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
            Cube[] cubes = _spawner.SpawnCubes(cube.transform, cube.SegmentationThreshold);
            Rigidbody[] rigidbodies = new Rigidbody[cubes.Length];

            for (int i = 0; i < cubes.Length; i++)
                rigidbodies[i] = cubes[i].GetComponent<Rigidbody>();

            _exploder.Explode(rigidbodies, cube.transform);
        }
        else
        {
            _exploder.Explode(cube.transform);
        }

        _destroyer.Destroy(cube);
    }
}