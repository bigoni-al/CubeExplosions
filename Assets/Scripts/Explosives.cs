using UnityEngine;

public class Explosives : MonoBehaviour
{
    [SerializeField] private float _explosionRadius = 5f;
    [SerializeField] private float _explosionForce = 200f;

    public float ExplosionRadius => _explosionRadius;
    public float ExplosionForce => _explosionForce;

    public void ChangeExplosivesParameters(float newExplosionRadius, float newExplosionForce)
    {
        _explosionRadius = newExplosionRadius;
        _explosionForce = newExplosionForce;
    }
}
