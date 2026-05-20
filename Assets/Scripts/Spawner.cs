using System;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;

    private int _countCubesMin = 2;
    private int _countCubesMax = 6;
    private int _shiftPositionCoefficient = 2;
    private int _shiftScaleCoefficient = 2;
    private int _shiftLuckCoefficient = 2;

    public event Action<List<Cube>, Vector3> CubesCreated;

    public void CreateCubes(Cube parentCube)
    {
        float shiftPosition = parentCube.transform.localScale.y / _shiftPositionCoefficient;
        Vector3 newScale = parentCube.transform.localScale / _shiftScaleCoefficient;
        int newPercentLuck = parentCube.LuckSplit / _shiftLuckCoefficient;
        int countNewCubes = UnityEngine.Random.Range(_countCubesMin, _countCubesMax + 1);

        List<Cube> newCubes = new();

        for (int i = 0; i < countNewCubes; i++)
        {
            Cube newCube = Instantiate(_cubePrefab, parentCube.transform.position + UnityEngine.Random.insideUnitSphere * shiftPosition, Quaternion.identity);
            newCube.transform.localScale = newScale;
            newCube.ChangeLuckSplit(newPercentLuck);

            newCubes.Add(newCube);
        }

        CubesCreated?.Invoke(newCubes, parentCube.transform.position);
    }
}