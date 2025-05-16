using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;


#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void setPlayerName(string name)
    {
        MainManager.PlayerName = name;
    }
}
