using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class BoatHealth : MonoBehaviour
{
    [SerializeField] private int _curHealth;
    [SerializeField] private int _maxHealth = 100;
    [SerializeField] private Sprite[] _healthBar;


    [SerializeField] private GameObject _boat;
    
    
    
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
