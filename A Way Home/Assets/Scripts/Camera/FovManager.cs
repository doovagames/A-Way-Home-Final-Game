using UnityEngine;
using UnityEngine.UI;

public class FovManager : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    private void Start()
    {
        var cam = GetComponent<UnityEngine.Camera>();
        if (cam != null)
        {
            cam.fov = GetFov();
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
