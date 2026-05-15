using System;
using UnityEngine;

public class Splitter : MonoBehaviour
{
    [SerializeField] private GameObject _cubePrefab;
    [SerializeField] private int _currentPercentLuck = 100;
    [SerializeField] private Transform _currentPosition;

    private Rigidbody _rigidbody;

    private int _numbersNewCubesMin = 2;
    private int _numbersNewCubesMax = 6;
    private int _percentLuckMin = 0;
    private int _percentLuckMax = 100;
    private int _shiftPositionCoefficient = 2;
    private int _shiftScaleCoefficient = 2;
    private int _shiftLuckCoefficient = 2;

    public Transform CurrentPosition => _currentPosition;

    public event Action CubeSplitted;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void SplitCube()
    {
        int randomNumberluck = UnityEngine.Random.Range(_percentLuckMin, _percentLuckMax);

        if (randomNumberluck <= _currentPercentLuck)
        {
            float shiftPosition = transform.localScale.y / _shiftPositionCoefficient;
            int numbersNewCubes = UnityEngine.Random.Range(_numbersNewCubesMin, _numbersNewCubesMax);

            Destroy(_rigidbody);

            for (int i = 0; i < numbersNewCubes; i++)
            {
                GameObject newCube = Instantiate(_cubePrefab);
                newCube.transform.localScale /= _shiftScaleCoefficient;

                Vector3 newPosition = new Vector3(
                    UnityEngine.Random.Range(transform.position.x - shiftPosition, transform.position.x + shiftPosition),
                    UnityEngine.Random.Range(transform.position.y - shiftPosition, transform.position.y + shiftPosition),
                    UnityEngine.Random.Range(transform.position.z - shiftPosition, transform.position.z + shiftPosition));
                newCube.transform.position = newPosition;

                newCube.GetComponent<Splitter>()._currentPercentLuck /= _shiftLuckCoefficient;
            }

            CubeSplitted?.Invoke();  
        }

        Destroy(gameObject);
    }
}