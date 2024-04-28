using UnityEngine;

public class CollisionSound : MonoBehaviour
{
    private AudioSource audioSource;

    private void Start()
    {
        // Assuming the AudioSource is attached to the same GameObject as this script,
        // you can get the AudioSource component in the Start method.
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Stick"))
        {
            // Check if AudioSource is not null before playing the sound.
            if (audioSource != null && audioSource.clip != null)
            {
                audioSource.Play();
            }
            else
            {
                Debug.LogWarning("AudioSource or AudioClip is missing.");
            }
        }
    }
}
