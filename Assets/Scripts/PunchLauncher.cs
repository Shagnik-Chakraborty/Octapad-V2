using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchLauncher : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float punchThreshold = 1.5f;
    [SerializeField] private float forceMultiplier = 2f;
    [SerializeField] private float cooldown = 0.5f;

    private float lastPunchTime;

    // Update is called once per frame
    void Update()
    {
        if (Time.time < lastPunchTime + cooldown) return;
        Vector3 controllerVelocity = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RTouch);
        Quaternion controllerRotation = OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTouch);
        float speed = controllerVelocity.magnitude;
        bool isPunchForward = Vector3.Dot(controllerVelocity.normalized, controllerRotation * Vector3.forward) > 0;

        if (speed > punchThreshold && isPunchForward)
        {
            Vector3 controllerPosition = OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch);
            FireProjectile(controllerPosition, controllerRotation, controllerVelocity);
        }
    }

    void FireProjectile(Vector3 position, Quaternion rotation, Vector3 velocity)
    {
        GameObject projectile = Instantiate(projectilePrefab, position, rotation);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        rb.AddForce(rotation * Vector3.forward * velocity.magnitude * forceMultiplier, ForceMode.VelocityChange);
        Destroy(projectile, 3f);
    }
}
