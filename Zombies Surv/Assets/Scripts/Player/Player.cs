using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private DeviceType deviceType;

    [Space]
    [SerializeField] private PlayerMovement movement;
    [SerializeField] private PlayerCombat combat;
    [SerializeField] private PlayerInteractions interactions;
    [SerializeField] private PlayerInventory inventory;
    [SerializeField] private PlayerCamera tdsCamera;
    [SerializeField] private HumanAnimations animations;

    public PlayerInventory Inventory { get => inventory; }

    private Vector3 moveDir;
    private Session session;

    public void Initialize()
    {
        session = Session.Instance;

        movement.Initialize(session.UI.HUD.MoveJoystick, session.UI.HUD.LookJoystick);
        inventory.Initialize();
        interactions.Initialize();
        combat.Initialize();
    }

    private void Update()
    {
        movement.MovementInputs(deviceType);
        movement.LookAndroid();

        interactions.CheckInteractablesAround();
    }

    private void FixedUpdate()
    {
        movement.Move(out moveDir);
    }

    private void LateUpdate()
    {
        animations.SetVelocity(moveDir.x, moveDir.z);
    }
}
