using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanAnimations : MonoBehaviour
{
    [SerializeField] private Animator anim;

    [Header("Keys")]
    [SerializeField] private string velocity_x_key = "velocity x";
    [SerializeField] private string velocity_z_key = "velocity z";
    [SerializeField] private string pistol_move_key = "pistolMove";
    [SerializeField] private string rifle_move_key = "rifleMove";
    [SerializeField] private string just_move_key = "justMove";

    public void SetVelocity(float x, float z)
    {
        anim.SetFloat(velocity_x_key, x, 0.1f, Time.deltaTime);
        anim.SetFloat(velocity_z_key, z, 0.1f, Time.deltaTime);
    }

    public void SetPistolMove() => anim.SetTrigger(pistol_move_key);
    public void SetRifleMove() => anim.SetTrigger(rifle_move_key);
    public void SetJustMove() => anim.SetTrigger(just_move_key);
}
