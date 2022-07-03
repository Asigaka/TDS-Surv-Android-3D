using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerMovement movement;
    [SerializeField] private PlayerCombat combat;
    [SerializeField] private PlayerInteractions interactions;
    [SerializeField] private PlayerInventory inventory;
    [SerializeField] private PlayerCamera tdsCamera;

    public PlayerInventory Inventory { get => inventory; }

    public void Initialize()
    {
        movement.Initialize();
        inventory.Initialize();
    }

    private void Update()
    {
        movement.MovementInputs();
        movement.Look();
    }

    private void FixedUpdate()
    {
        movement.Move();
    }
}
