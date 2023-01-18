using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score_Board : MonoBehaviour
{
    [SerializeField] int score_board_value;

    public int Get_Score_Board_Value()
    {
        return score_board_value;
    }
}
