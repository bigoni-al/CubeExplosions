using UnityEngine;

public class DestructionController : MonoBehaviour
{
    [SerializeField] private Pointer _pointer;
    [SerializeField] private CubeSpawner _cubeSpawner;
    [SerializeField] private Exploder _exploder;

    private int _percentLuckSplitMin = 0;
    private int _percentLuckSplitMax = 100;

    private void OnEnable()
    {
        _pointer.CubeFounded += DestroyCube;
    }

    private void OnDisable()
    {
        _pointer.CubeFounded -= DestroyCube;
    }

    private void DestroyCube(Cube cube)
    {
        int randomNumberLuckSplit = Random.Range(_percentLuckSplitMin, _percentLuckSplitMax + 1);

        if (randomNumberLuckSplit <= cube.CurrentPercentLuckSplit)
        {
            _cubeSpawner.CreateCubes(cube);
            _exploder.RememberCenterExplosion(cube.transform.position);
            Destroy(cube.gameObject);
            StartCoroutine(_exploder.LaunchDetonation());
        }
        else
        {
            Destroy(cube.gameObject);
        }
    }
}
