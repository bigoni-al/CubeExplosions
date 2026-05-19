using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;
    [SerializeField] private Exploder _exploder;

    private int _numbersNewCubesMin = 2;
    private int _numbersNewCubesMax = 6;
    private int _shiftPositionCoefficient = 2;
    private int _shiftScaleCoefficient = 2;
    private int _shiftLuckCoefficient = 2;

    public void CreateCubes(Cube parentCube)
    {
        float shiftPosition = parentCube.transform.localScale.y / _shiftPositionCoefficient;
        Vector3 newScale = parentCube.transform.localScale / _shiftScaleCoefficient;
        int newPercentLuck = parentCube.CurrentPercentLuckSplit / _shiftLuckCoefficient;
        int numbersNewCubes = Random.Range(_numbersNewCubesMin, _numbersNewCubesMax + 1);

        for (int i = 0; i < numbersNewCubes; i++)
        {
            Cube newCube = Instantiate(_cubePrefab, parentCube.transform.position, Quaternion.identity);
            newCube.transform.localScale = newScale;
            newCube.ChangePercentLuck(newPercentLuck);

            Vector3 newPosition = new(
                Random.Range(parentCube.transform.position.x - shiftPosition, parentCube.transform.position.x + shiftPosition),
                Random.Range(parentCube.transform.position.y - shiftPosition, parentCube.transform.position.y + shiftPosition),
                Random.Range(parentCube.transform.position.z - shiftPosition, parentCube.transform.position.z + shiftPosition));
            newCube.transform.position = newPosition;
        }
    }
}
