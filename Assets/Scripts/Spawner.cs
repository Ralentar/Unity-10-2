using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _prefab;

    private void Awake()
    {
        const string PrefabName = "CubePrefab Variant";

        _prefab = Resources.Load<Cube>(PrefabName);
    }

    public Cube[] SpawnCubes(Transform parent, float parentSegmentationThreshold)
    {
        int minValue = 2;
        int maxValue = 7;
        int count = Random.Range(minValue, maxValue);
        
        float scaleRatio = 0.5f;
        float segmentationThreshold = 0.5f;

        segmentationThreshold *= parentSegmentationThreshold;

        Vector3 position = new Vector3(parent.position.x, parent.position.y, parent.position.z);
        Vector3 localScale = parent.localScale * scaleRatio;

        Cube[] cubes = new Cube[count];

        for (int i = 0; i < count; i++)
            cubes[i] = CreateCube(position, localScale, segmentationThreshold);

        return cubes;
    }

    private Cube CreateCube(Vector3 position, Vector3 localScale, float segmentationThreshold)
    {
        float multiplier = 0.2f;

        Vector3 offset = Random.insideUnitSphere * position.magnitude * multiplier;
        offset.y = Mathf.Abs(offset.y);

        Cube cube = Instantiate(_prefab, position + offset, Quaternion.identity);

        cube.transform.localScale = localScale;
        cube.SetSegmentationThreshold(segmentationThreshold);

        return cube;
    }
}