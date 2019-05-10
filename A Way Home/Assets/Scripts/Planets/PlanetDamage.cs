using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetDamage : MonoBehaviour
{
    [SerializeField] private AudioSource _planetCollide;
    
    private void Start()
    {
        _planetCollide = gameObject.GetComponent<AudioSource>();
    }
    
    private void OnCollisionEnter(Collision col)
    {
        print(col);
        if (col.gameObject.tag == "Player")
        {
            var damage = Mathf.Round(200f);
            col.gameObject.GetComponentInParent<BoatHealth>().Damage(damage);
            _planetCollide.Play();
        }
    }
}
