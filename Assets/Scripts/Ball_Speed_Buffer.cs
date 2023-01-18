using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Speed_Buffer : MonoBehaviour
{
    [SerializeField] float scan_range;
    [SerializeField] LayerMask ball_layer;
    [SerializeField] Vector3 force_vector;
    [SerializeField] float force_strength;
    void Start()
    {
        Subscribe();
    }

    private void Subscribe()
    {
        Custom_Event_Manager.Instance.OnPlayerReachedPassage += Event_OnPlayerReachedPassage;
    }

    private void Event_OnPlayerReachedPassage(object sender, System.EventArgs e)
    {
        Buff_Balls();
    }

    private void Buff_Balls()
    {
        Collider[] ball_colliders = Physics.OverlapSphere(transform.position, scan_range, ball_layer);

        if (ball_colliders.Length > 0)
        {
            foreach (Collider ball_collider in ball_colliders)
            {
                ball_collider.gameObject.GetComponent<Rigidbody>().AddForce(force_vector * force_strength, ForceMode.Impulse);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, scan_range);
    }
}
