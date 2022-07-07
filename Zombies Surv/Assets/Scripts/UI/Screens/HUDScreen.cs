using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Enums;

public class HUDScreen : UIScreen
{
    [SerializeField] private Joystick moveJoystick;
    [SerializeField] private Joystick lookJoystick;
    [SerializeField] private Button interactBtn;
    [SerializeField] private Button inventoryBtn;

    public Button InteractBtn { get => interactBtn; }
    public Joystick MoveJoystick { get => moveJoystick; }
    public Joystick LookJoystick { get => lookJoystick; }

    public override void Initialize()
    {
        base.Initialize();

        SetInteractiveBtnActive(false);
        inventoryBtn.onClick.AddListener(OpenInventory);
    }

    public void SetInteractiveBtnActive(bool enabled)
    {
        interactBtn.gameObject.SetActive(enabled);
    }

    private void OpenInventory()
    {
        manager.SwitchScreen(ScreenType.Inventory);
    }
}
