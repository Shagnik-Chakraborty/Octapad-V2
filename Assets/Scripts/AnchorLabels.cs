using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchorLabels : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer;
   
    // Update is called once per frame
    private void Update()
    {
        Vector3 controllerPosition = OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch);
        Quaternion controllerRotation = OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTouch);
        Vector3 rayDirection = controllerRotation * Vector3.forward;

        if (Physics.Raycast(controllerPosition, rayDirection, out RaycastHit hit)) 
        {
            lineRenderer.SetPosition(0, controllerPosition);
            OVRSemanticClassification anchor = hit.collider.gameObject.GetComponentInParent<OVRSemanticClassification>();
            if (anchor != null)
            {
                print($"Hit an Anchor with the label: { string.Join(", ", anchor.Labels)}");
                Vector3 endpoint = anchor.transform.position;
                lineRenderer.SetPosition(1, endpoint);
            }
            else
            {
                lineRenderer.SetPosition(1, hit.point);
            }
        }
    }
}
