using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [SerializeField] float movement_speed;
    [SerializeField] float score_board_speed_buffer_value;
    Rigidbody rb;
    bool can_move = false;
    bool score_board_movement_activated;
    private void Awake()
    {
        Event_Listener();
    }
    void Start()
    {
        score_board_movement_activated = false;
        can_move = false;
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        if (!can_move) return;

        if (!score_board_movement_activated) Movement();
        else Score_Board_Controls();
    }

    private void Event_Listener()
    {
        Custom_Event_Manager.Instance.OnLevelStartTap += Event_OnLevelStartTap;
        Custom_Event_Manager.Instance.OnLevelLoaded += Event_OnLevelLoaded;
        Custom_Event_Manager.Instance.OnPlayerReachedPassage += Event_OnPlayerReachedPassage;
        Custom_Event_Manager.Instance.OnPlayerClearedPassage += Event_OnPlayerClearedPassage;
        Custom_Event_Manager.Instance.OnLevelFinish += Event_OnLevelFinish;
        Custom_Event_Manager.Instance.OnPlayerReachFinishLine += Event_OnPlayerReachFinishLine;
    }

    private void Event_OnPlayerReachFinishLine(object sender, System.EventArgs e)
    {
        score_board_movement_activated = true;
    }

    private void Event_OnLevelLoaded(object sender, System.EventArgs e)
    {
        can_move = false;
    }

    private void Event_OnPlayerClearedPassage(object sender, System.EventArgs e)
    {
        can_move = true;
        rb.isKinematic = false;
    }

    private void Event_OnPlayerReachedPassage(object sender, System.EventArgs e)
    {
        can_move = false;
        rb.velocity = Vector3.zero;
        rb.isKinematic = true;
    }

    private void Event_OnLevelStartTap(object sender, System.EventArgs e)
    {
        can_move = true;
    }

    private void Event_OnLevelFinish(object sender, System.EventArgs e)
    {
        can_move = false;
        score_board_movement_activated = false;
        rb.velocity = Vector3.zero;
        this.enabled = false;
    }
    private void Movement()
    {
        Vector3 direction, inputVector = Vector3.zero;

        float horizontal_value = Input.GetAxisRaw("Horizontal");

        inputVector.x = horizontal_value;
        inputVector.y = 0f;
        inputVector.z = 0f;

        direction = Vector3.forward + inputVector;
        rb.velocity = direction * movement_speed;
    }
    private void Score_Board_Controls()
    {
        Vector3 force_vector = Vector3.forward;
        //rb.velocity = Vector3.forward * movement_speed;

        if (Input.GetMouseButton(0))
        {
            rb.AddForce(force_vector * score_board_speed_buffer_value, ForceMode.Impulse);
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Began)
            {
                rb.AddForce(force_vector * score_board_speed_buffer_value, ForceMode.Impulse);
            }
        }
    }
}
