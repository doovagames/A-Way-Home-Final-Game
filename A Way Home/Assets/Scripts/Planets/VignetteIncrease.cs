using UnityEngine;
using UnityEngine.PostProcessing;


public class VignetteIncrease : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    private float _startX;
    public PostProcessingProfile _processing;

    [SerializeField] private float vir;
    
    // Start is called before the first frame update
    void Start()
    {
        var newSettings = _processing.vignette.settings;
        newSettings.intensity = 0;
        _processing.vignette.settings = newSettings;
        _startX = _playerTransform.position.x;
    }

    private void Update()
    {
        var vignetteSettings = _processing.vignette.settings;
        vignetteSettings.intensity = vir;
        _processing.vignette.settings = vignetteSettings;
    }
}
