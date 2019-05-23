using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{

    [SerializeField] private Animator _credits;

    private void Start()
    {
        Invoke("credits", 30f);
    }

    void credits ()
    {
        if (_credits.enabled == true)
        {
            SceneManager.LoadScene(0);
        }
    }
}
