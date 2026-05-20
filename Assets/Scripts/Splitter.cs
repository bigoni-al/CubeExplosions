using UnityEngine;

public class Splitter : MonoBehaviour
{
    [SerializeField] private RaySender _raySender;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Pusher _pusher;

    private int _luckSplitMin = 0;
    private int _luckSplitMax = 100;

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
        int randomLuckSplit = Random.Range(_luckSplitMin, _luckSplitMax + 1);

        if (randomLuckSplit <= cube.LuckSplit)
        {
            _spawner.CreateCubes(cube);
        }

        Destroy(cube.gameObject);    
    }
}
