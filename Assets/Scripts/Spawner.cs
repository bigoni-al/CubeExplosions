using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;

    private int _countCubesMin = 2;
    private int _countCubesMax = 6;
    private int _shiftPositionCoefficient = 2;
    private int _shiftScaleCoefficient = 2;
    private int _shiftChanceCoefficient = 2;

    public List<Cube> CreateCubes(Cube parentCube)
    {
        float shiftPosition = parentCube.transform.localScale.y / _shiftPositionCoefficient;
        Vector3 newScale = parentCube.transform.localScale / _shiftScaleCoefficient;
        int newChanceSplit = parentCube.ChanceSplit / _shiftChanceCoefficient;
        int countNewCubes = Random.Range(_countCubesMin, _countCubesMax + 1);
        List<Cube> newCubes = new();

        for (int i = 0; i < countNewCubes; i++)
        {
            Cube newCube = Instantiate(_cubePrefab, parentCube.transform.position + Random.insideUnitSphere * shiftPosition, Quaternion.identity);
            newCube.transform.localScale = newScale;
            newCube.ChangeChanceSplit(newChanceSplit);
            newCubes.Add(newCube);
        }

        return newCubes;
    }

    public void DestroyCube(Cube cube)
    {
        Destroy(cube.gameObject);
    }
}