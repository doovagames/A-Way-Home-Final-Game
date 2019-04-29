using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnim : MonoBehaviour
{
    [SerializeField] private Animator cameraAnim;
    
    // Start is called before the first frame update
    void Start()
    {
        cameraAnim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OptionsButton()
    {
        cameraAnim.SetInteger("CameraIndex",1);
    }
}
