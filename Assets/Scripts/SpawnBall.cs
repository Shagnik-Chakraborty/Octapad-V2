using UnityEngine;

public class SpawnBall : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    [SerializeField] private float force = 4.0f;

    // Update is called once per frame
    private void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        {
            Vector3 controllerPosition = OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch);
            Quaternion controllerRotation = OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTouch);
            GameObject spawnedBall = Instantiate(ball, controllerPosition, controllerRotation);
            Rigidbody rigidbody = spawnedBall.GetComponent<Rigidbody>();
            rigidbody.velocity = controllerRotation * Vector3.forward * force;
        }
    }
}
