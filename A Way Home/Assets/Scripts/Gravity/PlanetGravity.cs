using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetGravity : MonoBehaviour
{
    [SerializeField] private Rigidbody[] _generators; // These are the objects that generate the gravity field
    [SerializeField] private Rigidbody[] _affected; // These are the objects that are affected by the gravity
    [SerializeField] private float _gFactor = 0.1f; // This is the G Factor
    public Vector3[] forces; // The forces

    // Update is called once per frame
    void FixedUpdate()
    {
        // For each of the generators we create a force
        for (var ii = 0; ii < _generators.Length; ii++)
        {
            // For each of the affected objects
            for (var jj = 0; jj<_affected.Length;jj++)
            {
                // Check that is not the same object
                if (_generators[ii].name != _affected[jj].name)
                {
                  // We obtain the force value and it's vector
                    float _distance = (_generators[ii].position - _affected[jj].position).magnitude;
                    Vector3 _directionForce = (_generators[ii].position - _affected[jj].position) / _distance;
                    float _forceValue = (_generators[ii].mass * _affected[jj].mass) / Mathf.Pow(_distance, 2);
                    
                    /* Debug values for checking the force
                     Debug.Log (Distance)
                     Debug.Log (_directionForce)
                     Debug.Log (_forceValue)*/

                    forces[jj] += _gFactor * _forceValue * _directionForce;
                }
            }
        }
        
        // Apply Force
        for (int jj = 0; jj < _affected.Length; jj++)
        {
            _affected[jj].AddForce(forces[jj]);
            
            // Reset force
            forces [jj] = new Vector3();
        }
    }
}
