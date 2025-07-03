using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const int LeftMouseButton = 0;
    private const float MaxDistanceRay = 100;

    private Camera _camera;

    public event Action<RaycastHit> HitReceived;

    private void Awake()
    {
        _camera = GetComponent<Camera>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(LeftMouseButton))
        {
            ConvertMousePositionToHit();
        }
    }

    private void ConvertMousePositionToHit()
    {
        Vector3 mousePosition = Input.mousePosition;
        Ray ray = _camera.ScreenPointToRay(mousePosition);

        if(Physics.Raycast(ray, out RaycastHit hit, MaxDistanceRay))
        {
            HitReceived?.Invoke(hit);
        }
    }
}

