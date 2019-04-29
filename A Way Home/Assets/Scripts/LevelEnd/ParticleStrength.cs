using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleStrength : MonoBehaviour
{
    [SerializeField] private ParticleSystemRenderer _particle;
    [SerializeField] private Transform _player;
    [SerializeField] private float _distanceMultiplier;
    private Transform _particleTransform;

    private void Awake()
    {
        _particleTransform = _particle.transform;
    }

    private void Update()
    {
        var distance = Vector3.Distance(_player.position, _particleTransform.position);
        _particle.lengthScale = distance * _distanceMultiplier;
    }
}
