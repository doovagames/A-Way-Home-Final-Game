using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMusicTrigger : MonoBehaviour
{

    [SerializeField] private AudioClip _changeMusic;

    [SerializeField] private InGameMusic _theAM;

    // Start is called before the first frame update
    void Start()
    {
        _theAM = FindObjectOfType<InGameMusic>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (_changeMusic != null)
                _theAM.ChangeMusic(_changeMusic);
        }
    }
}
