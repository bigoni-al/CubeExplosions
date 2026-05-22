using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Dyer))]
public class Cube : MonoBehaviour
{
    [SerializeField] private int _chanceSplit = 100;

    public int ChanceSplit => _chanceSplit;

    public void ChangeChanceSplit(int newChanceSplit)
    {
        _chanceSplit = newChanceSplit;
    }
}