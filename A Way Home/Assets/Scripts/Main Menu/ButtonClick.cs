using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonClick : MonoBehaviour
{
   [SerializeField] private AudioSource _buttonClick
    {
        get { return GetComponent<AudioSource>(); }
    }
    
    [SerializeField] private Button _Button
    {
        get { return GetComponent<Button>(); }
    }
    // Start is called before the first frame update
    void Start()
    {
       _Button.onClick.AddListener(() => PlaySound());
    }

    void PlaySound()
    {
        _buttonClick.Play();
    }
}
