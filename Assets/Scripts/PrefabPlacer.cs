using UnityEngine;

public class PrefabPlacer : MonoBehaviour
{
    public GameObject prefab;
    public GameObject previewPrefab;
    private GameObject currentPreview;

    // Start is called before the first frame update
    private void Start()
    {
        currentPreview = Instantiate(previewPrefab);
        currentPreview.SetActive(false); // Disable the preview initially
    }

    // Update is called once per frame
    private void Update()
    {
        // Cast a ray from the controller
        Ray ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            // Update the preview's position and rotation
            currentPreview.SetActive(true);
            currentPreview.transform.position = hit.point;
            currentPreview.transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);

            // Place the prefab when the trigger button is pressed
            if (OVRInput.GetDown(OVRInput.Button.One))
            {
                // Instantiate the prefab relative to the hit point and rotation
                Instantiate(prefab, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
            }
        }
        else
        {
            // If the raycast doesn't hit anything, disable the preview
            currentPreview.SetActive(false);
        }
    }
}
