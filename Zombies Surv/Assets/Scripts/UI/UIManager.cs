using Enums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIManager : MonoBehaviour
{
    [SerializeField] private UIScreen[] screens;
    [SerializeField] private ScreenType startScreen;

    [Space]
    [SerializeField] private HUDScreen hud;
    [SerializeField] private InventoryScreen inventory;

    [HideInInspector] public UnityEvent onScreenChange;

    private ScreenType currentScreen;

    public HUDScreen HUD { get => hud; }
    public InventoryScreen Inventory { get => inventory; }

    public void Initialize()
    {
        foreach (UIScreen screen in screens)
        {
            screen.Initialize();
        }

        SwitchScreen(startScreen);
    }

    public void SwitchScreen(ScreenType toType)
    {
        foreach (UIScreen screen in screens)
        {
            screen.gameObject.SetActive(screen.ScreenType == toType);
        }

        currentScreen = toType;
        onScreenChange.Invoke();
    }

    public void ClearTransformChildren(Transform parent)
    {
        for (int i = 0; i < parent.childCount; i++)
        {
            Destroy(parent.GetChild(i).gameObject);
        }
    }
}
