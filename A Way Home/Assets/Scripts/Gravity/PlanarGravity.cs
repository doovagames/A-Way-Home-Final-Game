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
    
    // Start is called before the first frame update
    void Start()
    {
      Physics.gravity = Vector3.zero;  
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, _planetTarget.position);

        _targetDirection = transform.position - _planetTarget.position;
        _targetDirection = _targetDirection.normalized;

        if (distance < _gravityRadius)
        {
            GetComponent<Rigidbody>().AddForce(_targetDirection * _forceAmount * Time.deltaTime);
        }
    }

    void OnGizmosDraw()
    {
        Gizmos.color = _gizmosColor;
        Gizmos.DrawWireSphere(_planetTarget.position, _gravityRadius);
    }
}
