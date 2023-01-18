using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Road_Passage : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI ball_count_text_object;
    [SerializeField] int balls_required;
    [SerializeField] BoxCollider passage_collider;
    [SerializeField] int ball_score_value;
    int balls_count;
    bool player_hit = false;
    float cooldown = 3f;
    bool cooldown_active;
    private void Start()
    {
        balls_count = 0;
        cooldown_active = false;
        Subscribe();
        Update_Ball_Count_UI();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            player_hit = true;
            passage_collider.enabled = false;
            Custom_Event_Manager.Instance.Event_OnPlayerReachedPassage();
        }
    }

    private void Update()
    {
        if (cooldown_active) 
        {
            cooldown -= Time.deltaTime;

            if (cooldown < 0f) Custom_Event_Manager.Instance.Event_OnLevelFailed();
        } 
    }

    public void Ball_Collected()
    {
        balls_count++;
        Update_Ball_Count_UI();
        Level_Manager.Instance.Increase_Level_Score(ball_score_value);
        cooldown = 3f;

        if (balls_count >= balls_required) Custom_Event_Manager.Instance.Event_OnPassageBallRequirementFullfilled();
    }

    private void Update_Ball_Count_UI()
    {
        ball_count_text_object.text = balls_count.ToString() + " / " + balls_required.ToString();
    }

    public bool Get_Player_Hit()
    {
        return player_hit;
    }

    private void Subscribe()
    {
        Custom_Event_Manager.Instance.OnPassageBallRequirementFullfilled += Event_OnPassageBallRequirementFullfilled;
        Custom_Event_Manager.Instance.OnPlayerReachedPassage += Event_OnPlayerReachedPassage;
    }

    private void Event_OnPlayerReachedPassage(object sender, System.EventArgs e)
    {
        if (player_hit) cooldown_active = true;
    }

    private void Event_OnPassageBallRequirementFullfilled(object sender, System.EventArgs e)
    {
        if (player_hit) cooldown_active = false;
    }
}
