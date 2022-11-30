using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtoneManger : MonoBehaviour
{

    public void Play()
    {
        SceneManager.LoadScene("level1");
    }
    public void Exit()
    {

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit(); //does not work in the editor, it works when you compile
#endif
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("level1");
    }
}
