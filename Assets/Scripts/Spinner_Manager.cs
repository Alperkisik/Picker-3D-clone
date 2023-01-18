using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner_Manager : MonoBehaviour
{
    bool spinnerActive = false;
    float timer;
    [SerializeField] float cooldown;
    void Start()
    {
        Subscribe();
    }

    private void FixedUpdate()
    {
        if (spinnerActive)
        {
            timer -= Time.deltaTime;

            if (timer < 0)
            {
                timer = 0;
                spinnerActive = false;
                Deactivate_Spins();
            }
        }
    }

    private void Subscribe()
    {
        Custom_Event_Manager.Instance.OnPlayerHitClock += Event_OnPlayerHitClock;
    }

    private void Event_OnPlayerHitClock(object sender, System.EventArgs e)
    {
        if (!spinnerActive)
        {
            spinnerActive = true;
            timer = cooldown;
            Activate_Spins();
        }
        else timer += cooldown;
    }

    private void Activate_Spins()
    {
        transform.Find("Left_Spinner").gameObject.SetActive(true);
        transform.Find("Right_Spinner").gameObject.SetActive(true);
    }

    private void Deactivate_Spins()
    {
        transform.Find("Left_Spinner").gameObject.SetActive(false);
        transform.Find("Right_Spinner").gameObject.SetActive(false);
    }
}
