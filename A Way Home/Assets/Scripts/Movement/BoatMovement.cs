using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(Rigidbody))]
public class BoatMovement : MonoBehaviour
{
    [SerializeField] private float holdTime = .3f;
    [SerializeField] private float turnSpeed = 10f;
    [SerializeField] private float acceleration = 10f;

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
        float forwardForce = 0;
        float directionalForce = 0;
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
        else
        {
            _timeHeld = 0;
            
        }
        rbody.AddForce(transform.forward * forwardForce * acceleration * Time.deltaTime);
        // rbody.transform.Rotate(new Vector3(0,directionalForce * turnSpeed,0));
        rbody.AddTorque(0f, directionalForce * turnSpeed * Time.deltaTime, 0f);

        StartCoroutine(Movement());
    }

    IEnumerator Movement()
    {
        //print(Time.time);
        yield return new WaitForSeconds(5);
        //print(Time.time);
    }
}