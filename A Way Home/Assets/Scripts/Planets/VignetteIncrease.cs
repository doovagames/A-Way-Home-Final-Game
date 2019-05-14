using UnityEngine;
using UnityEngine.PostProcessing;

namespace Planets
{
    public class VignetteIncrease : MonoBehaviour
    {
        [SerializeField] private PostProcessingProfile _postProcessingProfile;
        [SerializeField] private Transform _boat;
        [SerializeField] private float _vignetteIntensity;
        [SerializeField] private float _distanceThreshold;
        [SerializeField] private float _teleportDelay;
        private float _startXPosition;

        private void Start()
        {
            _startXPosition = _boat.position.x;
        }

        private void SetIntensity(float newIntensity)
        {
            var settings = _postProcessingProfile.vignette.settings;
            settings.intensity = newIntensity;
            _postProcessingProfile.vignette.settings = settings;
        }

        private void Teleport()
        {
            var newPosition = new Vector3(_startXPosition, _boat.position.y, _boat.position.z);
            _boat.position = newPosition;
        }
    
        private void Update()
        {
            var difference = _boat.position.x - _startXPosition;
            difference = Mathf.Abs(difference);
            SetIntensity(difference * _vignetteIntensity);
            print(difference);

            if (difference > _distanceThreshold)
            {
                Invoke(nameof(Teleport), _teleportDelay);
            }
        }

        /*
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
    */
    }
}
