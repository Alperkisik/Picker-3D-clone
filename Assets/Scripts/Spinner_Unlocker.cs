using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner_Unlocker : MonoBehaviour
{
    [SerializeField] float animation_speed;
    bool up = true;
    bool do_animation = true;

    void Update()
    {
        if (do_animation) Animate();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            Custom_Event_Manager.Instance.Event_OnPlayerHitClock();
            do_animation = false;
            gameObject.SetActive(false);
        }
    }

    private void Animate()
    {
        Vector3 direction;
        float cap;

        if (up)
        {
            direction = Vector3.up;
            cap = 0.55f;
        }
        else
        {
            direction = Vector3.down;
            cap = 0.45f;
        }

        transform.Translate(direction * Time.deltaTime * animation_speed);

        if (transform.position.y <= cap) up = true;
        else if (transform.position.y >= cap) up = false;
    }
}
