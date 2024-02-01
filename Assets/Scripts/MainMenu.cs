using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject playerNameObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    [System.Serializable]
    class SavePlayerData
    {
        public string playerName;// = playerNameObject.GetComponent<TMP_InputField>().text;

        // When start game is pressed, save player name
    }

    public void SetPlayerName()
    {
        DataManager.Instance.playerName = playerNameObject.GetComponent<TMP_InputField>().text;
    }

    public void StartGame()
    {
        SetPlayerName();
        SceneManager.LoadScene(1);
        //if playerName == null, flash warning to input name
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
