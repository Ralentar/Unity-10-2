using UnityEngine;

public static class Dyer
{
    public static Color GetRandomColor()
    {
        return new Color(Random.value, Random.value, Random.value);
    }
}