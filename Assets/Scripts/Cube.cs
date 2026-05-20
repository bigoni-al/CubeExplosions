using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]

public class Cube : MonoBehaviour
{
    [SerializeField] private int _luckSplit = 100;

    private Renderer _renderer;

    public int LuckSplit => _luckSplit;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _renderer.material.color = Random.ColorHSV();
    }

    public void ChangeLuckSplit(int newLuckSplit)
    {
        _luckSplit = newLuckSplit;
    }
}