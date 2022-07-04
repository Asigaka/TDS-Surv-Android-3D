using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;

    private Rigidbody rb;
    private Joystick moveJoys;
    private Joystick lookJoys;
    private float turnSmoothVelocity;
    private Vector3 lookDir;
    private Vector3 moveDir;
    private float moveHor;
    private float moveVer;
    private float lookHor;
    private float lookVer;

    public void Initialize(Joystick move, Joystick look)
    {
        rb = GetComponent<Rigidbody>();

        moveJoys = move;
        lookJoys = look;
    }

    public void MovementInputs(DeviceType deviceType)
    {
        switch (deviceType)
        {
            case DeviceType.Desktop:
                moveHor = Input.GetAxisRaw("Horizontal");
                moveVer = Input.GetAxisRaw("Vertical");

                lookHor = lookJoys.Horizontal;
                lookVer = lookJoys.Vertical;
                break;
            case DeviceType.Handheld:
                lookHor = lookJoys.Horizontal;
                lookVer = lookJoys.Vertical;

                moveHor = moveJoys.Horizontal;
                moveVer = moveJoys.Vertical;
                break;
        }
    }

    public void LookAndroid()
    {
        lookDir = new Vector3(lookHor, 0, lookVer).normalized;

        float targetAngle;

        if (isLooking() || isRunning())
        {
            if (isLooking())
                targetAngle = Mathf.Atan2(lookDir.x, lookDir.z) * Mathf.Rad2Deg;
            else
                targetAngle = Mathf.Atan2(moveDir.x, moveDir.z) * Mathf.Rad2Deg;

            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, 0.1f);
            transform.rotation = Quaternion.Euler(0, angle, 0);
        }
    }

    public void LookPC()
    {

    }

    public void Move(out Vector3 direction)
    {
        moveDir = new Vector3(moveHor, 0, moveVer);

        if (isRunning())
        {
            moveDir.Normalize();
            rb.velocity = moveDir * speed;
        }


        direction = Vector3.zero;
        direction.z = Vector3.Dot(moveDir.normalized, transform.forward);
        direction.x = Vector3.Dot(moveDir.normalized, transform.right);
    }

    public bool isRunning()
    {
        return moveDir.magnitude >= 0.1f;
    }

    public bool isLooking()
    {
        return lookDir.magnitude >= 0.1f;
    }
}
