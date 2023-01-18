using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Ui_Manager : MonoBehaviour
{
    [SerializeField] GameObject game_ui_panel;
    [SerializeField] GameObject level_start_panel;
    [SerializeField] TextMeshProUGUI level_textmesh;
    [SerializeField] GameObject tap_textmesh;
    [SerializeField] TextMeshProUGUI score_textmesh;
    bool level_finish = false;
    void Start()
    {
        Subscribe();
    }

    private void Subscribe()
    {
        Custom_Event_Manager.Instance.OnLevelLoaded += Event_OnLevelLoaded;
        Custom_Event_Manager.Instance.OnLevelStartTap += Event_OnLevelStartTap;
        Custom_Event_Manager.Instance.OnPlayerReachFinishLine += Event_OnPlayerReachFinishLine;
        Custom_Event_Manager.Instance.OnLevelFinish += Event_OnLevelFinish;
        Custom_Event_Manager.Instance.OnScoreChanged += Event_OnScoreChanged;
    }

    private void Event_OnScoreChanged(object sender, System.EventArgs e)
    {
        score_textmesh.text = "Score " + Level_Manager.Instance.Get_Level_Score().ToString();
    }

    private void Event_OnLevelFinish(object sender, System.EventArgs e)
    {
        tap_textmesh.SetActive(false);
        level_finish = true;
    }

    private void Event_OnPlayerReachFinishLine(object sender, System.EventArgs e)
    {
        tap_textmesh.SetActive(true);
    }

    private void Event_OnLevelStartTap(object sender, System.EventArgs e)
    {
        game_ui_panel.SetActive(true);
        level_start_panel.SetActive(false);
        tap_textmesh.SetActive(false);
    }

    private void Event_OnLevelLoaded(object sender, System.EventArgs e)
    {
        game_ui_panel.gameObject.SetActive(false);
        level_start_panel.gameObject.SetActive(true);
        tap_textmesh.SetActive(false);
        level_textmesh.text = "Level " + (Game_Manager.Instance.Get_Level_Index() + 1).ToString();
    }

    public void Next_Level()
    {
        if (!level_finish) return;

        Game_Manager.Instance.Next_Level();
    }
    public void Retry_Level()
    {
        if (!level_finish) return;

        Game_Manager.Instance.Retry_Level();
    }
}
