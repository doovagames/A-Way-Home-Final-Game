using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    [SerializeField]
    private BoatHealth _boatHealth;
    [SerializeField] private AudioSource source;
    
    public int _addHealth = 15;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HealthPickup"))
        {
            source.Play();
            Pickup(other);
            Debug.Log("collide");
        }
    }

    public void Pickup(Collider pickup)
    {
        _boatHealth._curHealth += _addHealth;
        
        Destroy(pickup.gameObject);
    }
}
