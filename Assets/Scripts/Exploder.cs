using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    private float _explosionForce = 300;
    private float _explosionRadius = 10;

    public void Explode(List<Cube> cubes, Vector3 explodePosition)
    {
        foreach (Cube cube in cubes)
        {
            cube.Rigidbody.AddExplosionForce(_explosionForce, explodePosition, _explosionRadius);
        }
    }
}