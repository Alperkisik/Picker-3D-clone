using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road_Lift : MonoBehaviour
{
    [SerializeField] float lift_speed;
    bool lifting = false;
    Transform parent;
    Vector3 origin_position;

    void Start()
    {
        origin_position = transform.position;
        parent = transform.parent;
        Subscribe();
    }

    void Update()
    {
        if (lifting) Lift_Road();
    }

    void Subscribe()
    {
        Custom_Event_Manager.Instance.OnPassageBallRequirementFullfilled += Event_OnPassageBallRequirementFullfilled;
    }

    private void Event_OnPassageBallRequirementFullfilled(object sender, System.EventArgs e)
    {
        if (parent.GetComponent<Road_Passage>().Get_Player_Hit()) lifting = true;
    }

    private void Lift_Road()
    {
        transform.Translate(Vector3.up * Time.deltaTime * lift_speed);

        if (transform.position.y >= 0f)
        {
            transform.position = new Vector3(origin_position.x, 0f, origin_position.z);
            lifting = false;
            Custom_Event_Manager.Instance.Event_OnPlayerClearedPassage();
            //this.enabled = false;
        }
    }
}
