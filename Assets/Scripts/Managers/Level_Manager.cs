using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Manager : MonoBehaviour
{
    public static Level_Manager Instance { get; private set; }

    [SerializeField] Transform start_position;
    [SerializeField] GameObject playerPrefab;
    int level_score;

    private void Awake()
    {
        if (Instance != null && Instance != this) Destroy(this);
        else Instance = this;
    }

    void Start()
    {
        Subscribe();
        Spawn_Player();
        level_score = 0;
    }

    private void Subscribe()
    {
        Custom_Event_Manager.Instance.OnLevelLoaded += Event_OnLevelLoaded;
    }

    private void Event_OnLevelLoaded(object sender, EventArgs e)
    {
        //Spawn_Player();
        level_score = 0;
        Custom_Event_Manager.Instance.Event_OnScoreChanged();
    }

    private void Spawn_Player()
    {
        Instantiate(playerPrefab, start_position.position, Quaternion.identity, this.transform);
    }

    public void Increase_Level_Score(int value)
    {
        level_score += value;
        Custom_Event_Manager.Instance.Event_OnScoreChanged();
    }

    public void Multiply_Level_Score(int multiplier_value)
    {
        level_score *= multiplier_value;
        Custom_Event_Manager.Instance.Event_OnScoreChanged();
    }
    public int Get_Level_Score()
    {
        return level_score;
    }
}
