using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SaveDataManager saveData = new SaveDataManager();
        saveData.LoadFromJSON();
        DisplayBestScore();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DisplayBestScore()
    {
        Text bestScoreText = GameObject.Find("BestScore").GetComponent<Text>();
        bestScoreText.text = "Best Score: " + SaveDataManager.bestPlayer + ": " + SaveDataManager.bestScore;
    }

    public void StartGame()
    {
        SaveDataManager saveData = new SaveDataManager();
        saveData.SavePlayerName();
        SceneManager.LoadScene("main");
    }

    public void QuitGame()
    {
        SaveDataManager saveData = new SaveDataManager();
        saveData.SaveToJSON();

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    } 
}
