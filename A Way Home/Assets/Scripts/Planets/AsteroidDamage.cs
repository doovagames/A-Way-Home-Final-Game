using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidDamage : MonoBehaviour
{
    [SerializeField] private int damage;
    
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponentInParent<BoatHealth>().Damage(damage);
        }
    }
}
