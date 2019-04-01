using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForce : MonoBehaviour
{
    public Vector3 _forceAmount;
    [SerializeField] private Rigidbody rigidbody;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
            rigidbody.AddRelativeForce(_forceAmount);
    }
}
