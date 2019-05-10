using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddTorque : MonoBehaviour
{
    public Vector3 _torqueAmount;
    private Rigidbody _rigidbody;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
            _rigidbody.AddTorque(_torqueAmount);
    }
}
