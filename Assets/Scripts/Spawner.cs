using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(GameObject))]

public class Spawner : MonoBehaviour
{
    [SerializeField] private Object _prefab;

    private void Awake()
    {
        const string PrefabName = "CubePrefab Variant";

        _prefab = Resources.Load<Object>(PrefabName);
    }

    public Rigidbody[] SpawnCubes(Transform parent)
    {
        int minValue = 2;
        int maxValue = 7;
        int count = Random.Range(minValue, maxValue);
        float multiplier = 0.2f;
        float scaleRatio = 0.5f;
        float segmentationThreshold = 0.5f;

        segmentationThreshold *= parent.GetComponent<Cube>().SegmentationThreshold;

        Vector3 position = new Vector3(parent.position.x, parent.position.y, parent.position.z);
        Vector3 localScale = parent.localScale * scaleRatio;

        Rigidbody[] cubes = new Rigidbody[count];

        for (int i = 0; i < count; i++)
        {
            Vector3 offset = Random.insideUnitSphere * position.magnitude * multiplier;
            offset.y = Mathf.Abs(offset.y);

            Rigidbody cube = Instantiate(_prefab, position + offset, Quaternion.identity).GetComponent<Rigidbody>();

            cube.transform.localScale = localScale;
            cube.GetComponent<Cube>().SetSegmentationThreshold(segmentationThreshold);

            cubes[i] = cube;
        }

        return cubes;
    }
}