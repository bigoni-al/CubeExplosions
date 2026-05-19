using System.Collections;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionRadius = 20;
    [SerializeField] private float _explosionForce = 700;
    [SerializeField] private float _delayExplosion = 0.2f;

    private Vector3 _explosionPosition;

    private WaitForSecondsRealtime _wait;

    private void Awake()
    {
        _wait = new WaitForSecondsRealtime(_delayExplosion);
    }

    public IEnumerator LaunchDetonation()
    {
        yield return _wait;

        Explode();
    }

    private void Explode()
    {
        Collider[] hits = Physics.OverlapSphere(_explosionPosition, _explosionRadius);

        foreach (Collider hit in hits)
        {
            if (hit.TryGetComponent<Rigidbody>(out var rigidbody))
            {
                rigidbody.AddExplosionForce(_explosionForce, _explosionPosition, _explosionRadius);
            }
        }
    }

    public void RememberCenterExplosion(Vector3 explosionPosition)
    {
        _explosionPosition = explosionPosition;
    }
}
