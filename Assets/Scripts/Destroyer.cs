using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public void Destroy(Cube cube)
    {
        Destroy(cube.gameObject);
    }
}