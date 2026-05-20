using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private Splitter _splitter;

    private void OnEnable()
    {
        _splitter.CubeNotSplitted += Explode;
    }

    private void OnDisable()
    {
        _splitter.CubeNotSplitted -= Explode;
    }

    public void Explode(Cube cube)
    {
        float explosionRadius = cube.GetComponent<Explosives>().ExplosionRadius;
        float explosionForce = cube.GetComponent<Explosives>().ExplosionForce;

        Collider[] hits = Physics.OverlapSphere(cube.transform.position, explosionRadius);

        foreach (Collider hit in hits)
        {
            if (hit.TryGetComponent(out Rigidbody rigidbody))
            {
                rigidbody.AddExplosionForce(explosionForce, cube.transform.position, explosionRadius);
            }
        }
    }
}
