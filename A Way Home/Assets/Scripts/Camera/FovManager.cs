using UnityEngine;
using UnityEngine.UI;

public class FovManager : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    private void Start()
    {
        var camera = GetComponent<UnityEngine.Camera>();
        if (camera != null)
        {
            camera.fieldOfView = GetFov();
        }
    }

    public void UpdateFov()
    {
        PlayerPrefs.SetInt("FOV", (int)_slider.value);
    }

    public int GetFov()
    {
        return PlayerPrefs.GetInt("FOV", 60);
    }
}
