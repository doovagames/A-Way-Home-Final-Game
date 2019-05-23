using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FovCameraManager : MonoBehaviour
{
    [SerializeField] private UnityEngine.Camera _camera;

    private void Start()
    {
        _camera.fieldOfView = GetFov();
    }

    public int GetFov()
    {
        return PlayerPrefs.GetInt("FOV", 60);
    }
}
