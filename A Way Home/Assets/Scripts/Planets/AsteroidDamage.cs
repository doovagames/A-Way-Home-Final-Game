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
            var damage = Mathf.Round(Random.Range(1f, 10f));
            col.gameObject.GetComponentInParent<BoatHealth>().Damage(damage);
        }
    }
}
