using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(Rigidbody))]
public class BoatMovement : MonoBehaviour
{
    [SerializeField] private float holdTime = .3f;
    [SerializeField] private float turnSpeed = 10f; // How fast the boat turns
    [SerializeField] private float acceleration = 10f; // How fast the boat moves

    [SerializeField] private Rigidbody rbody;
    private float _timeHeld;
    [SerializeField] private AudioSource _source;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Giving Foward force so that player can move foward
        float forwardForce = 0;
        //Giving Directional force so that the player can move clockwise/ anti-clockwise
        float directionalForce = 0;
        
        //Controls for Mouse Input
        if (Input.GetKey(KeyCode.Mouse0) || Input.GetKey(KeyCode.Mouse1))
        {
            _timeHeld += Time.deltaTime;
            
            if (Input.GetKey(KeyCode.Mouse0) && _timeHeld < holdTime)
            {
                _source.Play();
                directionalForce = -1f;
                forwardForce = 1;
            }
            if (Input.GetKey(KeyCode.Mouse1) && _timeHeld < holdTime)
            {
                _source.Play();
                directionalForce = 1f;
                forwardForce = 1;
            }
            print(directionalForce);
        }
        //Controls for Controller Input
        if (Input.GetAxisRaw("Xbox L2") > 0.8 || Input.GetAxisRaw("Xbox R2") > 0.8)
        {
            _timeHeld += Time.deltaTime;
            
            if (Input.GetAxisRaw("Xbox L2") > 0.8 && _timeHeld < holdTime)
            {
                _source.Play();
                directionalForce = -1f;
                forwardForce = 1;
            }

            if (Input.GetAxisRaw("Xbox R2") > 0.8 && _timeHeld < holdTime)
            {
                _source.Play();
                directionalForce = 1f;
                forwardForce = 1; 
            } 
        }
        
        else
        {
            _timeHeld = 0;
            
        }
        rbody.AddForce(transform.forward * forwardForce * acceleration * Time.deltaTime);
        // rbody.transform.Rotate(new Vector3(0,directionalForce * turnSpeed,0));
        rbody.AddTorque(0f, directionalForce * turnSpeed * Time.deltaTime, 0f);
    }
}