using System;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    private Ray _ray;

    private int _buttonMouseLeft = 0;

    public event Action<Ray> ButtonPressed;

    private void Update()
    {
        if (Input.GetMouseButtonDown(_buttonMouseLeft))
        {
            _ray = _camera.ScreenPointToRay(Input.mousePosition);

            ButtonPressed?.Invoke(_ray);
        }
    }
}
