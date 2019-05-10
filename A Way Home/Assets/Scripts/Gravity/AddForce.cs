using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class AddForce : MonoBehaviour
{
    public Vector3 _forceAmount; // Referencing the Vector3 force.
    public Rigidbody rigidbody; // Referencing the rigidbody within the asteroid.
    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>(); // Gets the rigidbody which is attached to the asteroid.
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rigidbody.AddRelativeForce(_forceAmount); // Adds the relevant force for the asteroid.
    }
}
