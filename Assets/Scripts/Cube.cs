using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Dyer))]
[RequireComponent(typeof(Explosives))]

public class Cube : MonoBehaviour
{
    [SerializeField] private int _luckSplit = 100;

    //private Vector3 _position;

    public int LuckSplit => _luckSplit;

    public void ChangeLuckSplit(int newLuckSplit)
    {
        _luckSplit = newLuckSplit;
    }
}