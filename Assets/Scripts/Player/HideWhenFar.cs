using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideWhenFar : MonoBehaviour
{
    void Start()
    {
        camera = Camera.main;
        renderers = GetComponentsInChildren<Renderer>();
    }


    public Camera camera; // Assign your camera in the Inspector
    public Renderer[] renderers; // Assign your mesh's Renderer in the Inspector

    void Update()
    {
        foreach (var item in renderers)
            item.enabled = IsMeshInFrustum(camera, item.bounds);
    }

    bool IsMeshInFrustum(Camera cam, Bounds bounds)
    {
        // Get the camera's frustum planes
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(cam);

        // Check if the bounds are within the frustum
        return GeometryUtility.TestPlanesAABB(planes, bounds);
    }
}
