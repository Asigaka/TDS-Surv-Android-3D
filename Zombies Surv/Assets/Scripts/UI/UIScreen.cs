using Enums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIScreen : MonoBehaviour
{
    [SerializeField] private ScreenType screenType;

    public ScreenType ScreenType { get => screenType; }

    protected bool initialized;
    protected UIManager manager;

    public virtual void Initialize()
    {
        initialized = true;
        manager = Session.Instance.UI;
    }
}
