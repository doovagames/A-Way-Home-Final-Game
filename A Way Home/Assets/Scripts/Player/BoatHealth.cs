using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BoatHealth : MonoBehaviour
{
    [SerializeField] private int _curHealth;
    [SerializeField] private int _maxHealth = 100;
    
    // Start is called before the first frame update
    void Start()
    {
        _curHealth = _maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (_curHealth > _maxHealth)
        {
            _curHealth = _maxHealth;
        }

        if (_curHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Restarts the game and loads active scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("A Way Home Final Game");
    }

    public void Damage(int amount)
    {
        _curHealth -= amount;
    }
}
