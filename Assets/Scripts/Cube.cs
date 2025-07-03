using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    [SerializeField] private float _splitChance = 100f;

    private Transform _transform;
    private Renderer _renderer;

    public Vector3 LocalScale => _transform.localScale;
    public float SplitChance => _splitChance;

    private void Awake()
    {
        _transform = transform;
        _renderer = GetComponent<Renderer>();
    }

    public void Initialize(Color color, Vector3 scale, float splitChance)
    {
        ChangeColor(color);
        ChangeScale(scale);
        _splitChance = splitChance;
    }

    public void ChangeColor(Color color)
    {
        _renderer.material.color = color;
    }

    public void ChangeScale(Vector3 scale)
    {
        _transform.localScale = scale;
    }
}