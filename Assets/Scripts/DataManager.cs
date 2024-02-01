using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public string playerName;
    public int highScore;
    public string highScorePlayer;
    // Start is called before the first frame update
    void Start()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        GetHighScore();
    }

    [System.Serializable]
    class HighScore
    {
        public int highScore;
        public string highScorePlayer;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GetHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            Debug.Log("Save File Exists");
            string json = File.ReadAllText(path);
            HighScore data = JsonUtility.FromJson<HighScore>(json);

            highScore = data.highScore;
            highScorePlayer = data.highScorePlayer;
            Debug.Log(highScore);
            Debug.Log(highScorePlayer);
        }
    }

    public void SaveHighScore()
    {
        HighScore data = new HighScore();
        data.highScore = highScore;
        data.highScorePlayer = highScorePlayer;

        string json = JsonUtility.ToJson(data);

        Debug.Log(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
}
