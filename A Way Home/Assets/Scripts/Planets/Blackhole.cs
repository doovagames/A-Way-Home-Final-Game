using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class Blackhole : MonoBehaviour
{
    [SerializeField] private float timeMultiplier;
    public GameObject _blackhole; // The blackhole game obj that the boat will orbit around when in it.

    public ParticleSystem _Blackhole;
    
    [SerializeField] private float _gravityPull = .78f;
    public static float _mGravityRadius = 1f;

    private void Start()
    {
        _Blackhole.Play();
    }

    private void Awake()
    {
        _mGravityRadius = GetComponent<SphereCollider>().radius;
    }

    // <summary>
    // Attract objects towards an area when they come within the bounds of a collider
    // This function is on the physics timer so it won't necessarily run every frame
    // <summary>
    // <param name="other">Any object within reach of gravity's collider</param>
    
    void OnTriggerStay(Collider other)
    {
        _gravityPull += Time.deltaTime * timeMultiplier;
        
        if(other.attachedRigidbody)
        {
            float gravityIntensity = Vector3.Distance(transform.position, other.transform.position) / _mGravityRadius;
            other.attachedRigidbody.AddForce((transform.position - other.transform.position) * gravityIntensity * other.attachedRigidbody.mass * _gravityPull * Time.smoothDeltaTime);
            Debug.DrawRay(other.transform.position, transform.position - other.transform.position);
            
            if (other.gameObject.tag == "Player")
            {
                var damage = Mathf.Round(Random.Range(10f, 40f)); // Deal random range of damage whilst in collider
                other.gameObject.GetComponentInParent<BoatHealth>().Damage(damage); // Referencing BoatHealth so that boat can be damaged.
            }
        }
    }
}
