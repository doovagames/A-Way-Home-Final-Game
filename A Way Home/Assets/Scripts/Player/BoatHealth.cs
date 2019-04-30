using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class BoatHealth : MonoBehaviour
{
    public float _curHealth;
    public float _maxHealth = 200;
    public Light _boatLight;

    [SerializeField] private float _restartDelay = 2f;

    [SerializeField] private GameObject _boat;
    
    [SerializeField] private AudioSource _source;
    
    
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

        _boatLight.intensity = _curHealth / 100;
        
        if (_curHealth <= 0f)
        {
            _source.Play();
            Die();
        }
    }

    void Die()
    {
        // Disable all the children.
        var children = transform.GetComponentsInChildren<Transform>();
        for (var index = 1; index < children.Length; index++)
        {
            var child = children[index];
            child.gameObject.SetActive(false);
        }

        print($"X position: {transform.position.x}, Y Position: {transform.position.x}");
        Invoke("Restart", _restartDelay);
    }

    private void Restart()
    {
        // Restarts the game and loads active scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Damage(float amount)
    {
        _curHealth -= amount;
    } 
}
