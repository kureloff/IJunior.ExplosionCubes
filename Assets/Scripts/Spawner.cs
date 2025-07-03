using UnityEngine;

public class Spawner : MonoBehaviour
{
    private const int Division = 2;

    private void Start()
    {
        CreateCube(new Vector3(2, 0, 0));
        CreateCube(new Vector3(0, 0, 0));
        CreateCube(new Vector3(-2, 0, 0));
    }

    public void CreateCube(Vector3 position)
    {
        GameObject spawnObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Cube cube = spawnObject.AddComponent<Cube>();
        spawnObject.transform.position = position;
    }

    public GameObject CreateFragments(GameObject spawnObject)
    {
        GameObject fragment = Instantiate(spawnObject);
        Cube cubeFragment = fragment.GetComponent<Cube>();

        Color color = ColorChanger.GetRandomColor();
        Vector3 scale = cubeFragment.LocalScale / Division;
        float splitChance = cubeFragment.SplitChance / Division;

        cubeFragment.Initialize(color, scale, splitChance);

        return fragment;
    }

    public void DestroyObject(Cube cube)
    {
        Destroy(cube.gameObject);
    }
}