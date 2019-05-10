using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidDamage : MonoBehaviour
{

    [SerializeField] private AudioSource _Collision;

    private void Start()
    {
        _Collision = gameObject.GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision col)
    {
        print(col);
        if (col.gameObject.tag == "Player")
        {
            var damage = Mathf.Round(Random.Range(1f, 10f));
            col.gameObject.GetComponentInParent<BoatHealth>().Damage(damage);
            _Collision.Play();
        }
    }
}
