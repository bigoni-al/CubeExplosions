using UnityEngine;

public class Dyer : MonoBehaviour
{
    private Renderer _renderer;

    private float _colorComponentMin = 0f;
    private float _colorComponentMax = 1f;
    private float _alfaComponent = 1f;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        ChangeColor();
    }

    public void ChangeColor()
    {
        Color newColor = new(Random.Range(_colorComponentMin, _colorComponentMax),
            Random.Range(_colorComponentMin, _colorComponentMax),
            Random.Range(_colorComponentMin, _colorComponentMax), _alfaComponent);
        _renderer.material.color = newColor;
    }

}
