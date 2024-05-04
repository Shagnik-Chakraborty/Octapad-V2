using UnityEngine;
public class RayController : MonoBehaviour
{
    public LineRenderer rayRenderer;
    public Transform rightController;

    void Update()
    {
        // Get the right controller's position and orientation
        Vector3 controllerPosition = OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch);
        Quaternion controllerRotation = OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTouch);

        // Calculate the ray origin and direction
        Vector3 rayOrigin = rightController.TransformPoint(controllerPosition);
        Vector3 rayDirection = rightController.TransformDirection(Vector3.forward);

        // Cast a ray from the controller
        Ray ray = new Ray(rayOrigin, rayDirection);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            // If the ray hits something, set the end position of the line renderer to the hit point
            rayRenderer.SetPosition(1, hit.point);
        }
        else
        {
            // If the ray doesn't hit anything, set the end position of the line renderer to a point in front of the controller
            rayRenderer.SetPosition(1, ray.origin + ray.direction * 100);
        }
    }
}
