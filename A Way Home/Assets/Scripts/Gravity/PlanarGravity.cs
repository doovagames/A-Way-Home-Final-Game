using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlanarGravity : MonoBehaviour
{
    public Transform _planetTarget;
    public float _forceAmount = 1000f;
    public float _gravityRadius = 10f;
    public Color _gizmosColor = Color.red;

    private Vector3 _targetDirection;
    private Rigidbody rigidbody1;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody1 = GetComponent<Rigidbody>();
        Physics.gravity = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, _planetTarget.position);

        _targetDirection = _planetTarget.position - transform.position ;
        _targetDirection = _targetDirection.normalized;

        if (distance < _gravityRadius)
        {
            rigidbody1.AddForce(_targetDirection * _forceAmount * Time.deltaTime);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = _gizmosColor;
        Gizmos.DrawWireSphere(_planetTarget.position, _gravityRadius);
    }

}
