using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    public void Play()
    {
        SceneManager.LoadScene(0);
    }
    public void LoadExit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
      Application.Quit();
#endif
    }
    // Update is called once per frame
    void Update()
    {

    }
}



