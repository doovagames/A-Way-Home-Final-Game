using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddTorque : MonoBehaviour
{
    public Vector3 _torqueAmount;
    [SerializeField] private Rigidbody rigidbody;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
            rigidbody.AddTorque(_torqueAmount);
    }
}
