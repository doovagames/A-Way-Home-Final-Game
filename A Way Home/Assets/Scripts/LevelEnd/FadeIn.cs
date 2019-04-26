using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIn : MonoBehaviour
{
    [SerializeField] private Animator _fadeIn;
    
    // Start is called before the first frame update
    void Start()
    {
        _fadeIn.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        _fadeIn.enabled = true;
        print("_fadeIn.enabled = true");
    }
}
