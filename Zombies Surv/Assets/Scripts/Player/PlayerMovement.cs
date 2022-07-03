using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Joystick moveJoys;
    [SerializeField] private Joystick lookJoys;

    [Space]
    [SerializeField] private float speed;

    private Rigidbody rb;
    private float turnSmoothVelocity;
    private Vector3 lookDir;
    private Vector3 moveDir;
    private float moveHor;
    private float moveVer;
    private float lookHor;
    private float lookVer;

    public void Initialize()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void MovementInputs()
    {
#if UNITY_EDITOR
        moveHor = Input.GetAxisRaw("Horizontal");
        moveVer = Input.GetAxisRaw("Vertical");
#else
        moveHor = moveJoys.Horizontal;
        moveVer = moveJoys.Vertical;
#endif
        lookHor = lookJoys.Horizontal;
        lookVer = lookJoys.Vertical;
    }

    public void Look()
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

    public void Move()
    {
        moveDir = new Vector3(moveHor, 0, moveVer).normalized;

        if (isRunning())
        {
            rb.velocity = moveDir * speed;
        }
    }

    public void RotateToTarget(Transform target)
    {
        transform.LookAt(target);
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
