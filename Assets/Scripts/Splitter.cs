using System.Collections.Generic;
using UnityEngine;

public class Splitter : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private InputHandler _inputHendler;
    [SerializeField] private RaySender _raySender;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Exploder _exploder;

    private int _chanceSplitMin = 0;
    private int _chanceSplitMax = 100;

    private void OnEnable()
    {
        _inputHendler.ButtonPressed += TryGetCube;
    }

    private void OnDisable()
    {
        _inputHendler.ButtonPressed += TryGetCube;
    }

    private void TryGetCube(Vector3 mousePosition)
    {
        Cube cube = _raySender.FindCube(_camera, mousePosition);

        if (cube != null)
        {
            TrySplitCube(cube);
        }
    }

    private void TrySplitCube(Cube cube)
    {
        int randomChanceSplit = Random.Range(_chanceSplitMin, _chanceSplitMax + 1);

        if (randomChanceSplit <= cube.ChanceSplit)
        {
            List<Cube> newCubes = _spawner.CreateCubes(cube);
            _exploder.Explode(newCubes, cube.transform.position);
        }

        _spawner.DestroyCube(cube);
    }
}
