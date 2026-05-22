using System;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private int _buttonMouseLeft = 0;

    public event Action<Vector3> ButtonPressed;

    private void Update()
    {
        if (Input.GetMouseButtonDown(_buttonMouseLeft))
        {
            ButtonPressed?.Invoke(Input.mousePosition);
        }
    }
}
