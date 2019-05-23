using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeIn : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            print("oof");
            _animator.SetTrigger("Fade In");
            Invoke ("EndGame", 20f);
        }
    }

    void EndGame()
    {
        if (_animator.enabled == true)
        {
            SceneManager.LoadScene(2);
        }
    }
}
