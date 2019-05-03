using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(Rigidbody))]
public class BoatMovement : MonoBehaviour
{
    [SerializeField] private float pressInterval = .3f;
    [SerializeField] private float turnSpeed = 10f; // How fast the boat turns
    [SerializeField] private float acceleration = 10f; // How fast the boat moves

    [SerializeField] private Rigidbody _rbody;
    private float _timesSincePress;
    [SerializeField] private AudioSource _source;

    // Start is called before the first frame update
    void Start()
    {
        _rbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _timesSincePress += Time.fixedDeltaTime;
        
        //Giving Forward force so that player can move forward
        float forwardForce = 0;
        //Giving Directional force so that the player can move clockwise/ anti-clockwise
        float directionalForce = 0;

        //Controls for Mouse Input
        if ((Input.GetKey(KeyCode.Mouse0) || Input.GetKey(KeyCode.Mouse1)) && _timesSincePress > pressInterval)
        {
            _timesSincePress = 0;

            if (Input.GetKey(KeyCode.Mouse0))
            {
                _source.Play();
                directionalForce = -5f;
                forwardForce = 5;
            }

            if (Input.GetKey(KeyCode.Mouse1))
            {
                _source.Play();
                directionalForce = 5f;
                forwardForce = 5;
            }
        }
        //Controls for Controller Input
        else if (Input.GetAxisRaw("Xbox L2") > 0.8 || Input.GetAxisRaw("Xbox R2") > 0.8 && _timesSincePress > pressInterval)
        {
            _timesSincePress = 0;

            if (Input.GetAxisRaw("Xbox L2") > 0.8)
            {
                _source.Play();
                directionalForce = -1f;
                forwardForce = 1;
            }

            if (Input.GetAxisRaw("Xbox R2") > 0.8)
            {
                _source.Play();
                directionalForce = 1f;
                forwardForce = 1;
            }
        }
        
        _rbody.AddForce(transform.forward * forwardForce * acceleration * Time.deltaTime);
        //rbody.transform.Rotate(new Vector3(0,directionalForce * turnSpeed,0));
        _rbody.AddTorque(0f, directionalForce * turnSpeed * Time.deltaTime, 0f);
    }
}