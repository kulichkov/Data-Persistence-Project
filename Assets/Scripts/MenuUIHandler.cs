using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public TextMeshProUGUI BestScoreText;

    void Start()
    {
        Debug.Log("Start MenuUIHandler");
        BestScoreText.text = MainManager.Instance.GetLastBestScoreText();
    }

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
        MainManager.Instance.CurrentPlayerName = name;
    }
}
