using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIn : MonoBehaviour
{
    [SerializeField] private Animator _fadeIn;
    [SerializeField] private Canvas _ImageFade;
    
    // Start is called before the first frame update
    void Start()
    {
        _fadeIn.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _fadeIn.SetBool("FadeIn", true);
        }
    }
}
