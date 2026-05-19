using System;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Ray _ray;

    public event Action<Cube> CubeFounded;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            _ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(_ray, out RaycastHit hit, Mathf.Infinity))
            {
                if (hit.collider.TryGetComponent<Cube>(out Cube cube))
                {
                    CubeFounded?.Invoke(cube);
                }
            }
        }
    }
}