using UnityEngine;

public class VoiceLine : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource; // Referencing the AudioSource
    [SerializeField] private AudioClip _voiceLine; // Referencing the AudioClip

    // Only does this if the player is inside the triggger
    private void OnTriggerEnter(Collider other)
    {
        //If the tag of the boat is named player
        if (other.gameObject.tag == "Player")
        {
            //Play the audio clip
            _audioSource.PlayOneShot(_voiceLine);
        }
    }
}