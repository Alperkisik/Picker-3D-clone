using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score_Board_Position_Checker : MonoBehaviour
{
    [SerializeField] float scan_range;
    [SerializeField] LayerMask score_Board_Layer;
    void Start()
    {
        Subscribe();
    }
    private void Subscribe()
    {
        Custom_Event_Manager.Instance.OnScoreBoardTimerFinished += Event_OnScoreBoardTimerFinished;
    }

    private void Event_OnScoreBoardTimerFinished(object sender, System.EventArgs e)
    {
        Multiply_Score();
    }

    private void Multiply_Score()
    {
        Collider[] score_Board_colliders = Physics.OverlapSphere(transform.position, scan_range, score_Board_Layer);

        if (score_Board_colliders.Length > 0) Level_Manager.Instance.Multiply_Level_Score(score_Board_colliders[0].transform.parent.GetComponent<Score_Board>().Get_Score_Board_Value());
        else Level_Manager.Instance.Multiply_Level_Score(1);
        Custom_Event_Manager.Instance.Event_OnLevelComplited();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, scan_range);
    }
}
