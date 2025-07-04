using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    private const float ExplosionForce = 300;
    private const float ExplosionRadius = 10;

    public void Explode(List<Cube> cubes, Vector3 explodePosition)
    {
        foreach (Cube cube in cubes)
            if (cube.TryGetComponent(out Rigidbody rigidbody))
                rigidbody.AddExplosionForce(ExplosionForce, explodePosition, ExplosionRadius);
    }
}