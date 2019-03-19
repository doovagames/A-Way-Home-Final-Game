using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParralaxBackground : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;

    [SerializeField] private MeshRenderer _meshrenderer;
    
    // Start is called before the first frame update
    void Awake()
    {
        _meshrenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Time.time * _speed;
        
        Vector2 offset = new Vector2(x, 0);
        
        _meshrenderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }
}
