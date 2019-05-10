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
            newSettings.intensity = 15 * Time.deltaTime;
            Processing.vignette.settings = newSettings;
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
}
