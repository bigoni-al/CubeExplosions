using UnityEngine;

public class RaySender : MonoBehaviour
{
    private Ray _ray;

    public Cube FindCube(Camera camera, Vector3 mousePosition)
    {
        _ray = camera.ScreenPointToRay(mousePosition);

        if (Physics.Raycast(_ray, out RaycastHit hit, Mathf.Infinity))
        {
            if (hit.collider.TryGetComponent(out Cube cube))
            {
                return cube;
            }
        }

        return null;
    }
}
