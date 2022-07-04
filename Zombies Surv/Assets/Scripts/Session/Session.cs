using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Session : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private UIManager ui;

    public static Session Instance;

    public Player Player { get => player; }
    public UIManager UI { get => ui; }

    private void Awake()
    {
        if (Instance)
            Destroy(Instance);

        Instance = this;
    }

    private void Start()
    {
        StartSession();
    }

    private void StartSession()
    {
        ui.Initialize();
        player.Initialize();
    }
}
