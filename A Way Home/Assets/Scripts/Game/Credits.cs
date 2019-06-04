using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{

    [SerializeField] private Animator _credits;
    [SerializeField] private Animator _whiteFade;
    [SerializeField] private GameObject _FadeObj;

    private void Start()
    {
        Invoke("Credit", 30f);
    }

    private void Update()
    {
        if (!_whiteFade.GetCurrentAnimatorStateInfo(0).IsName("FadeOut"))
        {
            _FadeObj.SetActive(false);
        }
    }

    void Credit ()
    {
        if (_credits.enabled)
        {
            SceneManager.LoadScene(0);
        }
    }
}
