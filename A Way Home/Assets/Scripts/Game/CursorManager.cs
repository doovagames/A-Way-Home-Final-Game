using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{

    [SerializeField] private Dialogue _dialogue;
    private bool _isFinished;
    
    // Start is called before the first frame update
    private void OnEnable()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnDisable()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    private void Update()
    {
        if (_dialogue.isActiveAndEnabled)
        {
            OnDisable();
        }
        else
        {
            return;
        }
    }
}
