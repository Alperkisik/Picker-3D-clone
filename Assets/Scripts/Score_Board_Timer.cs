using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score_Board_Timer : MonoBehaviour
{
    [SerializeField] float cooldown;
    bool timer_active = false;
    void Start()
    {
        Subscribe();
    }

    void Update()
    {
        if (timer_active)
        {
            cooldown -= Time.deltaTime;

            if (cooldown < 0f)
            {
                timer_active = false;
                Custom_Event_Manager.Instance.Event_OnScoreBoardTimerFinished();
            }
        }
    }

    private void Subscribe()
    {
        Custom_Event_Manager.Instance.OnPlayerReachFinishLine += Event_OnPlayerReachFinishLine;
    }

    private void Event_OnPlayerReachFinishLine(object sender, System.EventArgs e)
    {
        timer_active = true;
    }
}
