using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed;
    public float TurnSpeed;
    public float Sensitivity;
    public VariableJoystick FloatingJoystick;
    public Rigidbody rb;

    public void FixedUpdate()
    {
        var joystickDir = FloatingJoystick.Direction;

        if (joystickDir == Vector2.zero)
        {

            rb.isKinematic = true;
            rb.velocity = Vector3.zero;
            return;
        }
        rb.isKinematic = false;

        var dir = new Vector3(joystickDir.x, 0, joystickDir.y) * Sensitivity;
        rb.velocity = transform.forward * Speed;
        var lookDir = new Vector3(dir.x, 0, dir.z);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookDir), TurnSpeed * Time.deltaTime);
    }
}
