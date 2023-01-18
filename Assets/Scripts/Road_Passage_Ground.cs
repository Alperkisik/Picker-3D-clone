using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road_Passage_Ground : MonoBehaviour
{
    Transform parent;
    void Start()
    {
        Subscribe();
        parent = transform.parent;
    }

    private void Subscribe()
    {
        Custom_Event_Manager.Instance.OnPlayerClearedPassage += Event_OnPlayerClearedPassage;
    }

    private void Event_OnPlayerClearedPassage(object sender, System.EventArgs e)
    {
        if(parent.GetComponent<Road_Passage>().Get_Player_Hit()) this.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Ball")
        {
            collision.transform.gameObject.SetActive(false);
            parent.GetComponent<Road_Passage>().Ball_Collected();
        }
    }
}
