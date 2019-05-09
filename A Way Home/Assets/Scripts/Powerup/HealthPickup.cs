using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    [SerializeField] private BoatHealth _boatHealth;
    [SerializeField] private AudioSource source;

    [SerializeField] private ParticleSystem _healthPickup;
    [SerializeField] private GameObject _HealthPickup;
    
    public int _addHealth = 15;

    private void Start()
    {
        _healthPickup.Play();
    }

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
        _HealthPickup.SetActive(false);
    }
}
