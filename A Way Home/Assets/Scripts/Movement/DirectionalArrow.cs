using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalArrow : MonoBehaviour
{

    [SerializeField] private GameObject _target;

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = _target.transform.position;
        targetPosition.y = transform.position.y;
        targetPosition.x = transform.position.x;
        transform.LookAt(targetPosition);
    }
}
