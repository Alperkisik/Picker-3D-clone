using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    bool follow = false;
    GameObject player;
    [SerializeField] Vector3 distance;
    // Start is called before the first frame update
    void Start()
    {
        Subscribe();
    }

    // Update is called once per frame
    void Update()
    {
        if (follow)
        {
            transform.position = player.transform.position - distance;
        }
    }

    void Subscribe()
    {
        Custom_Event_Manager.Instance.OnLevelStart += Event_OnLevelStart;
    }

    private void Event_OnLevelStart(object sender, System.EventArgs e)
    {
        follow = true;
        player = GameObject.FindGameObjectWithTag("Player");
    }
}
