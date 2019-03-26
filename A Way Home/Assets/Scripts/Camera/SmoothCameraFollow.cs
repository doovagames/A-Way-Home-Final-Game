using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCameraFollow : MonoBehaviour
{
    public GameObject _boat; // GameObject to follow

    [SerializeField] private float _distanceOffset = 6.0f; // Distance behind follow object
    [SerializeField] private float _heightOffset = 2.0f; // Distance above follow object

    [SerializeField] private float _springConstant = 10.0f; // How hard should the camera try to get to it's ideal position
    float _dampConstant;
}
