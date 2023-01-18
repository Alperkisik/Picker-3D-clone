using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Finish_Check : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Custom_Event_Manager.Instance.Event_OnPlayerReachFinishLine();
            GetComponent<BoxCollider>().enabled = false;
        }
    }
}
