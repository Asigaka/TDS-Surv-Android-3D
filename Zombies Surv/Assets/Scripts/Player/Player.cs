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

    public void Initialize()
    {
        movement.Initialize();
        inventory.Initialize();
        interactions.Initialize();
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
