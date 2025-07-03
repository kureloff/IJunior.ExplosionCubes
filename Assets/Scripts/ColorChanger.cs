using UnityEngine;

public static class ColorChanger
{
    public static Color GetRandomColor() =>
        new Color(Random.value, Random.value, Random.value);
}