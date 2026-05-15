using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionRadius = 20;
    [SerializeField] private float _explosionForce = 1000;
    [SerializeField] private Splitter _splitter;

    private void OnEnable()
    {
        _splitter.CubeSplitted += Explode;
    }

    private void OnDisable()
    {
        _splitter.CubeSplitted -= Explode;
    }

    public void Explode() 
    {
        Collider[] hits = Physics.OverlapSphere(_splitter.CurrentPosition.transform.position, _explosionRadius);

        foreach (Collider hit in hits)
        {
            Rigidbody rigidbody = hit.GetComponent<Rigidbody>();

            if (rigidbody != null)
            {
                rigidbody.AddExplosionForce(_explosionForce, _splitter.CurrentPosition.transform.position, _explosionRadius);
            }
        }
    }
}
