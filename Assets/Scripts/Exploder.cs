using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _pushRadius = 20;
    [SerializeField] private float _pushForce = 700;

    public void Explode(List<Cube> cubes, Vector3 positionPush)
    {
        foreach (Cube cube in cubes)
        {
            if (cube.TryGetComponent(out Rigidbody rigidbody))
            {
                rigidbody.AddExplosionForce(_pushForce, positionPush, _pushRadius);
            }
        }
    }
}
