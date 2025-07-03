using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Divider : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private Exploder _exploder;
    [SerializeField] private Spawner _spawner;

    private const int MinPercent = 0;
    private const int MaxPercent = 100;

    private const int MinCountFragments = 2;
    private const int MaxCountFragments = 6;

    private void OnEnable()
    {
        _inputReader.HitReceived += TryDivide;
    }

    private void OnDisable()
    {
        _inputReader.HitReceived -= TryDivide;
    }

    private void TryDivide(RaycastHit hit)
    {
        if (hit.collider.TryGetComponent(out Cube cube))
        {
            GameObject cubeObject = cube.gameObject;
            List<GameObject> fragments = new List<GameObject>();

            if (Random.Range(MinPercent, MaxPercent) <= cube.SplitChance)
            {
                Divide(cubeObject, fragments);
            }

            _spawner.DestroyObject(cube);
        }
    }

    private void Divide(GameObject cubeObject, List<GameObject> fragments)
    {
        int randomCount = Random.Range(MinCountFragments, MaxCountFragments);

        for (int i = 0; i < randomCount; i++)
        {
            fragments.Add(_spawner.CreateFragments(cubeObject));
        }

        _exploder.Explode(fragments, cubeObject.transform.position);
    }
}

