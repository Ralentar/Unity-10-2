using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] int _force = 500;
    [SerializeField] int _radius = 5;

    public void Explode(Rigidbody[] cubes, Transform center)
    {
        foreach (Rigidbody explosiveObject in cubes)
            explosiveObject.AddExplosionForce(_force, center.position, _radius);
    }

    public void Explode(Transform center)
    {
        center.gameObject.SetActive(false);

        float radius = CalculateRadius(center);
        List<Rigidbody> explosiveObjects = FindTargets(center, radius);

        foreach (Rigidbody explosiveObject in explosiveObjects)
        {
            float force = CalculateForce(center, explosiveObject.transform);

            explosiveObject.AddExplosionForce(force, center.position, radius);
        }
    }

    private List<Rigidbody> FindTargets(Transform center, float radius)
    {
        Collider[] hits = Physics.OverlapSphere(center.position, radius);

        List<Rigidbody> rigidbodies = new();

        for (int i = 0; i < hits.Length; i++)
            if (hits[i].GetComponent<Rigidbody>() != null)
                rigidbodies.Add(hits[i].attachedRigidbody);

        return rigidbodies;
    }

    private float CalculateForce(Transform center, Transform target)
    {
        return _force / center.localScale.x / Vector3.Distance(center.position, target.position);
    }

    private float CalculateRadius(Transform center)
    {
        return _radius / center.localScale.x;
    }
}