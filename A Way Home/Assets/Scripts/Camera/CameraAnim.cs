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
    
    // When button is pressed move camera positive value
    public void OptionsButton()
    {
        cameraAnim.SetInteger("CameraIndex",1);
    }
    
    // When back button pressed move camera negative value
    public void BackOptionsButton()
    {
        cameraAnim.SetInteger("CameraIndex",0);
    }
}
