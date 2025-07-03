using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    private float _explosionForce = 300;
    private float _explosionRadius = 10;

    public void Explode(List<GameObject> gameObjects, Vector3 explodePosition)
    {
        foreach (GameObject gameObject in gameObjects)
            if (gameObject.TryGetComponent(out Rigidbody rigidbody))
                rigidbody.AddExplosionForce(_explosionForce, explodePosition, _explosionRadius);
    }
}