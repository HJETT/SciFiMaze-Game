using UnityEngine;

public class HideWhenFar : MonoBehaviour
{
    void Start()
    {
        cam = Camera.main;
        renderers = GetComponentsInChildren<Renderer>();
    }


    private Camera cam; // Assign your camera in the Inspector
    private Renderer[] renderers; // Assign your mesh's Renderer in the Inspector

    void Update()
    {
        foreach (var item in renderers)
            item.enabled = IsBoundInFrustum(cam, item.bounds);
    }

    bool IsBoundInFrustum(Camera cam, Bounds bounds)
    {
        // Get the camera's frustum planes
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(cam);

        // Check if the bounds are within the frustum
        return GeometryUtility.TestPlanesAABB(planes, bounds);
    }
}
