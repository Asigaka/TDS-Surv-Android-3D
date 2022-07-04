using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDScreen : UIScreen
{
    [SerializeField] private Button interactBtn;

    public Button InteractBtn { get => interactBtn; }

    public override void Initialize()
    {
        base.Initialize();

        SetInteractiveBtnActive(false);
    }

    public void SetInteractiveBtnActive(bool enabled)
    {
        interactBtn.gameObject.SetActive(enabled);
    }
}
