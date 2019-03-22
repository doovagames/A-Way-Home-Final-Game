using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCameraFollow : MonoBehaviour
{
    public Transform _playerTransform;

    [SerializeField] private Vector3 _cameraOffset;

    [Range(0.01f, 1.0f)] public float _smoothFactor = 1f;

    public bool _lookAtPlayer = false;
    
    // Use this for initialization
    private void Start()
    {
        _cameraOffset = transform.position - _playerTransform.position;
    }
    
    // LateUpdate is called after the update methods
    private void LateUpdate()
    {
        Vector3 newPos = _playerTransform.position + _cameraOffset;
        
        transform.position = Vector3.Slerp(transform.position, newPos, _smoothFactor);

        if (_lookAtPlayer)
            transform.LookAt(_playerTransform);
    }
}
