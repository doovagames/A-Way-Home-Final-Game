using UnityEngine;
using UnityEngine.PostProcessing;


public class VignetteIncrease : MonoBehaviour
{
    [SerializeField] private BoatHealth _boatHealth;
    
    [SerializeField] private Transform _playerTransform;
    public PostProcessingProfile Processing;
    
    // Start is called before the first frame update
    private void Start()
    {
        var newSettings = Processing.vignette.settings;
        newSettings.intensity = 0;
        Processing.vignette.settings = newSettings;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var newSettings = Processing.vignette.settings;
            newSettings.intensity = 50 * Time.deltaTime;
            Processing.vignette.settings = newSettings;
            Teleport();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var newSettings = Processing.vignette.settings;
            newSettings.intensity = 0 * Time.deltaTime;
            Processing.vignette.settings = newSettings;      
        }
    }

    void Teleport()
    {
        if (Processing.vignette.settings.intensity == 1)
        {
            Invoke("ResetPosition",10f);
            print("teleport");
        }
    }

    void ResetPosition()
    {
        _playerTransform.position = new Vector3(550, _playerTransform.position.y, -1914);
        print("reset position");
    }
}
