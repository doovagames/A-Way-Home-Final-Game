using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{

    public void LoadByIndex(int sceneIndex)  //This will load the specific scene that the scene is on.
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneIndex); //Load scene number.
    }

    public void Quit() // Quit the game
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit ();
#endif
    }
    
}
