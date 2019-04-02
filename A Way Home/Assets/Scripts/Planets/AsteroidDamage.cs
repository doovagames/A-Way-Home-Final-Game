using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidDamage : MonoBehaviour
{
    private void OnCollisionEnter(Collision col)
    {
        print(col);
        if (col.gameObject.tag == "Player")
        {
            var damage = Mathf.RoundToInt(Random.Range(1, 10));
            col.gameObject.GetComponentInParent<BoatHealth>().Damage(damage);
            
        }
    }
}
