using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParralaxBackground : MonoBehaviour
{
    [SerializeField] private float _scrollSpeed = 10f;
    [SerializeField] private Vector2 _startPos;


    void Start()
    {
        _startPos = transform.position;
    }

    private void Update()
    {
        float newPos = Mathf.Repeat(Time.time * _scrollSpeed, 1000);
        transform.position = _startPos + Vector2.right * newPos;
    }
}
