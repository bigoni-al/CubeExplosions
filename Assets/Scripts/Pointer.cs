using UnityEngine;

public class Pointer : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Ray _ray;
    [SerializeField] private float _maxDistance = 100;
    [SerializeField] private float _radius = 0.1f;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            _ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(_ray, out RaycastHit hit, Mathf.Infinity))
            {
                hit.collider.GetComponent<Splitter>().SplitCube();
            }
        }
    }
}
