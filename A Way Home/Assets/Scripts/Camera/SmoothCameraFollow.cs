using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;


public class SmoothCameraFollow : MonoBehaviour
{
    public GameObject _boat; // GameObject to follow

    [SerializeField] private float _distanceOffset = 6.0f; // Distance behind follow object
    [SerializeField] private float _heightOffset = 2.0f; // Distance above follow object
    [SerializeField] private float _springConstant = 10.0f; // How hard should the camera try to get to its ideal position
    private float _dampConstant; // Dampens the speed of the camera (worked out in the Start function)
    Vector3 _velocity = new Vector3(0.0f, 0.0f, 0.0f); // How fast the camera is moving on each axis
    
    // Use this for initialization
    private void Start()
    {
        _dampConstant = 2.0f * Mathf.Sqrt(_springConstant); // Damp constant is equal to 2 multiplied by the square root of the spring constant
    }
    
    // Update is called once per frame
    private void FixedUpdate()
    {
        // Find the ideal position
        var _idealPosition = _boat.transform.position + -_boat.transform.forward * _distanceOffset + _boat.transform.up * _heightOffset;
       
        // Find how far away we are from the ideal position
        var _displacement = transform.position - _idealPosition;
        
        // Calculate how fast we should be moving towards our initial position using displacement and velocity
        var _acceleration = -_springConstant * _displacement - _dampConstant * _velocity;
        
        // Continually add desired acceleration to velocity
        _velocity += _acceleration * Time.deltaTime;
        
        // Use velocity to determine what position should be
        transform.position = new Vector3(
                                         transform.position.x + _velocity.x * Time.deltaTime,
                                         transform.position.y + _velocity.y * Time.deltaTime, 
                                         transform.position.z + _velocity.z * Time.deltaTime);
        
        // Look at the target
        transform.LookAt(_boat.transform);
    }
}


