using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Dyer))]

public class Cube : MonoBehaviour
{
    [SerializeField] private int _luckSplit = 100;

    public int LuckSplit => _luckSplit;

    public void ChangeLuckSplit(int newLuckSplit)
    {
        _luckSplit = newLuckSplit;
    }
}