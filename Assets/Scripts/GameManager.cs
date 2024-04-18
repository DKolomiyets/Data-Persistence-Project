using System;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public string UserName;

    public int UserScore = 0;

    public void SaveScore()
    {
        var data = new TopScore { UserName = UserName, Score = UserScore };
        var json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/scores.json", json);
    }

    public void LoadScore()
    {
        var path = Application.persistentDataPath + "/scores.json";
        if(File.Exists(path))
        {
            var json = File.ReadAllText(path);
            var data = JsonUtility.FromJson<TopScore>(json);
            UserName = data.UserName;
            UserScore = data.Score;
        }
    }

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadScore();
    }

    [Serializable]
    class TopScore
    {
        public string UserName;

        public int Score;
    }
}
