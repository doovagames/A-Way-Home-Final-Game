using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    private AudioSource source;
    public AudioClip _powerUp;
    
    public int _addHealth = 15;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            source.PlayOneShot(_powerUp, 1F);
            Pickup(other);
            
        }
    }

    public void Pickup(Collider player)
    {
        source.PlayOneShot(_powerUp, 1F);
        Destroy(gameObject);
    }
}
