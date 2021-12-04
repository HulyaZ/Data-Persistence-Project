using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public int bestScorea;
    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void SaveAndExit()
    {
        
        if (PlayerDataHandler.Instance != null)
        {
            PlayerDataHandler.Instance.SaveHighScore();
        }

       
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void Exit()
    {
        
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}


