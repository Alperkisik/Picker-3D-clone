using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner_Rotation : MonoBehaviour
{
    enum Direction
    {
        left, right
    }

    [SerializeField] float spin_speed = 30f;
    [SerializeField] Direction direction;
    [SerializeField] Transform cylinderTransform;

    Vector3 directionVector;
    new Rigidbody rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        if (direction == Direction.left) directionVector = Vector3.up;
        else directionVector = Vector3.up * -1f;
    }

    private void Update()
    {
        transform.position = cylinderTransform.position;
    }

    private void FixedUpdate()
    {
        rigidbody.AddTorque(directionVector * spin_speed);
    }
}
