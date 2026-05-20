using System.Collections.Generic;
using UnityEngine;

public class Pusher : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private float _pushRadius = 20;
    [SerializeField] private float _pushForce = 700;

    private void OnEnable()
    {
        _spawner.CubesCreated += PushCubes;
    }

    private void OnDisable()
    {
        _spawner.CubesCreated -= PushCubes;
    }

    public void PushCubes(List<Cube> cubes, Vector3 positionPush)
    {
        for(int i = 0; i < cubes.Count; i++)
        {
            if (cubes[i].TryGetComponent<Rigidbody>(out var rigidbody))
            {
                rigidbody.AddExplosionForce(_pushForce, positionPush, _pushRadius);
            }
        }
    }
}
