using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddTorque : MonoBehaviour
{
    public Vector3 _torqueAmount; // Referencing the Vector3 torque.
    public Rigidbody _rigidbody; // Referencing the rigidbody within the asteroid.
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody>(); // Gets the rigidbody which is attached to the asteroid.
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       _rigidbody.AddTorque(_torqueAmount); // Adds the relevant torque for the asteroid.
    }
}
