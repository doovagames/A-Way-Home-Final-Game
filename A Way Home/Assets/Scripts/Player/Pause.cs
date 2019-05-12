using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{

    [SerializeField] private Canvas _pauseMenu;
    
    // Start is called before the first frame update
    void Start()
    {
        _pauseMenu.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            PauseGame();

        }
        else
        {
            ContinueGame();
        }
    }

    void ContinueGame()
    {
        Time.timeScale = 1;
        Cursor.visible = false;
        _pauseMenu.enabled = false;
    }

    void PauseGame()
    {
        Time.timeScale = 0;
        Cursor.visible = true;
        _pauseMenu.enabled = true;
    }
}
