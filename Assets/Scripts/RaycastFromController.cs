using UnityEngine;

public class SimpleControllerRaycast : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public Transform controllerTransform;
    public float maxRaycastDistance = 10f;
    public LayerMask layerMask;
    public Color hitColor = Color.red; // Color to change objects on collision

    void Update()
    {
        if (Physics.Raycast(controllerTransform.position, controllerTransform.forward, out RaycastHit hit, maxRaycastDistance, layerMask))
        {
            lineRenderer.SetPosition(0, controllerTransform.position);
            lineRenderer.SetPosition(1, hit.point);

            // Check if the object hit has the tag "Stick"
            if (hit.collider.CompareTag("Stick") == false)
            {
                // Change the color of the object hit
                Renderer renderer = hit.collider.GetComponent<Renderer>();
                if (renderer != null)
                {
                    renderer.material.color = hitColor;
                }
            }
        }
        else
        {
            lineRenderer.SetPosition(0, controllerTransform.position);
            lineRenderer.SetPosition(1, controllerTransform.position + controllerTransform.forward * maxRaycastDistance);
        }
    }
}
