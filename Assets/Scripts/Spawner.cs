using UnityEngine;

public class Spawner : MonoBehaviour
{
    private const float StartSplitChance = 100;
    private const int DivisionScale = 2;
    private const int DivisionSplitChance = 2;

    [SerializeField] private GameObject _prefab;

    private void Start()
    {
        CreateCube(new Vector3(2, 0, 0));
        CreateCube(new Vector3(0, 0, 0));
        CreateCube(new Vector3(-2, 0, 0));
    }

    public Cube CreateFragments(Cube cube)
    {
        GameObject fragment = Instantiate(cube.gameObject);
        Cube cubeFragment = fragment.GetComponent<Cube>();

        cubeFragment.Exploded += DestroyCube;

        Color color = ColorChanger.GetRandomColor();
        Vector3 scale = cube.LocalScale / DivisionScale;
        float splitChance = cube.SplitChance / DivisionSplitChance;

        cubeFragment.Initialize(color, scale, splitChance);

        return cubeFragment;
    }

    private void DestroyCube(Cube cube)
    {
        cube.Exploded -= DestroyCube;
        Destroy(cube.gameObject);
    }

    private void CreateCube(Vector3 position)
    {
        GameObject spawnObject = Instantiate(_prefab);
        Cube cube = spawnObject.GetComponent<Cube>();

        cube.Exploded += DestroyCube;

        Color color = ColorChanger.GetRandomColor();

        cube.Initialize(color, spawnObject.transform.localScale, StartSplitChance);
        spawnObject.transform.position = position;
    }
}