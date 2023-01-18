using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu_Manager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI level_title;

    void Start()
    {
        level_title.text = "Level " + PlayerPrefs.GetInt("Last_Level", 0).ToString();
    }

    public void Game_Scene()
    {
        SceneManager.LoadScene("Game Scene");
    }
}
