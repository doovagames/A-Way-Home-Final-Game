using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class BoatHealth : MonoBehaviour
{
    public int _curHealth;
    public int _maxHealth = 100;
    public Light _boatLight;


    [SerializeField] private GameObject _boat;
    
    [SerializeField] private AudioSource _source;
    
    
    // Start is called before the first frame update
    void Start()
    {
        //_curHealth = _maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (_curHealth > _maxHealth)
        {
            _curHealth = _maxHealth;
        }

        _boatLight.intensity = (float)_curHealth / _maxHealth;
        
        if (_curHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        _source.Play();
        
        Destroy(_boat);
        
        // Restarts the game and loads active scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("A Way Home Final Game");
    }

    public void Damage(int amount)
    {
        _curHealth -= amount;
    } 
}
