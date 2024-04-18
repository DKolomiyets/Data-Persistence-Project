using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIHandler : MonoBehaviour
{
    public TextMeshProUGUI BestScoreText;

    private string m_UserName;

    public void NewUserNameEntered(string userName)
    {
        m_UserName = userName;
    }
    
    void Start()
    {
        var lastPlayedUser = GameManager.Instance.UserName;
        var lastScore = GameManager.Instance.UserScore;
        if(!string.IsNullOrEmpty(lastPlayedUser))
        {
            BestScoreText.text = $"Best Score: {lastPlayedUser}: {lastScore}";
        }
    }

    public void StartNew()
    {
        if(m_UserName != GameManager.Instance.UserName)
        {
            GameManager.Instance.UserName = m_UserName;
            GameManager.Instance.UserScore = 0;
        }
        SceneManager.LoadScene("main");
    }

    public void Exit()
    {
        GameManager.Instance.SaveScore();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
}
