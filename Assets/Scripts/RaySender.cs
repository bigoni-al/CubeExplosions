using System;
using UnityEngine;

public class RaySender : MonoBehaviour
{
    [SerializeField] private InputHandler _inputHandler;

    public event Action<Cube> CubeFounded;

    private void OnEnable()
    {
        _inputHandler.ButtonPressed += FindCube;
    }

    private void OnDisable()
    {
        _inputHandler.ButtonPressed -= FindCube;
    }

    private void FindCube(Ray ray) 
    {
        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity))
        {
            if (hit.collider.TryGetComponent(out Cube cube))
            {
                CubeFounded?.Invoke(cube);
            }
        }
    }
}
