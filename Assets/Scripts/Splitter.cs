using System;
using UnityEngine;

public class Splitter : MonoBehaviour
{
    [SerializeField] private RaySender _raySender;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Pusher _pusher;

    private int _luckSplitMin = 0;
    private int _luckSplitMax = 100;

    public event Action<Cube> CubeNotSplitted;

    private void OnEnable()
    {
        _raySender.CubeFounded += TrySplitCube;
    }

    private void OnDisable()
    {
        _raySender.CubeFounded -= TrySplitCube;
    }

    private void TrySplitCube(Cube cube)
    {
        int randomLuckSplit = UnityEngine.Random.Range(_luckSplitMin, _luckSplitMax + 1);

        if (randomLuckSplit <= cube.LuckSplit)
        {
            _spawner.CreateCubes(cube);
        }
        else 
        {
            CubeNotSplitted?.Invoke(cube);
        }

        Destroy(cube.gameObject);    
    }
}
