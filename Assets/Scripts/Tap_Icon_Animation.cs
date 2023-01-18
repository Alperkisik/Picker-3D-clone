using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tap_Icon_Animation : MonoBehaviour
{
    [SerializeField] float animation_speed;
    bool right = true;
    bool do_animation = true;
    float zAngle_Value = 0f;
    void Start()
    {
        Subscribe();
    }

    void Update()
    {
        if (do_animation) Animate();
    }

    private void Subscribe()
    {
        Custom_Event_Manager.Instance.OnLevelStartTap += Event_OnLevelStartTap;
        Custom_Event_Manager.Instance.OnLevelLoaded += Event_OnLevelLoaded;
    }

    private void Event_OnLevelLoaded(object sender, System.EventArgs e)
    {
        do_animation = true;
        transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
    }

    private void Event_OnLevelStartTap(object sender, System.EventArgs e)
    {
        do_animation = false;
        transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
    }

    private void Animate()
    {
        float zAngle_multiplier;

        if (right) zAngle_multiplier = -0.1f;
        else zAngle_multiplier = 0.1f;

        transform.Rotate(0f, 0f, zAngle_multiplier * animation_speed);

        if (transform.rotation.z < -0.20f)
        {
            right = false;
            zAngle_Value = -20f;
        }
        else if (transform.rotation.z > 0f)
        {
            right = true;
            zAngle_Value = 0f;
        }
    }
}
