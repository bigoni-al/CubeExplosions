using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Dyer))]

public class Cube : MonoBehaviour
{
    [SerializeField] private int _currentPercentLuckSplit = 100;

    public int CurrentPercentLuckSplit => _currentPercentLuckSplit;

    public void ChangePercentLuck(int newPercentLuckSplit)
    {
        _currentPercentLuckSplit = newPercentLuckSplit;
    }
}
