using System;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] private Canvas _pauseMenu;
    private bool _isPaused;
    private bool _hasReleased;
    

    private void Update()
    {
        if (Math.Abs(Input.GetAxisRaw("Cancel")) >= 0.9 && _hasReleased)
        {
            _hasReleased = false;
            TogglePause();
        }
        else if (Math.Abs(Input.GetAxisRaw("Cancel")) <= 0.1)
        {
            _hasReleased = true;
        }
    }

    private void TogglePause()
    {
        _isPaused = !_isPaused;
        Time.timeScale = _isPaused ? 0 : 1;
        _pauseMenu.enabled = _isPaused;
        Cursor.visible = !Cursor.visible;
    }
}
