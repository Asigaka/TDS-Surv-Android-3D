using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanAnimations : MonoBehaviour
{
    [SerializeField] private Animator anim;

    [Header("Keys")]
    [SerializeField] private string velocity_x_key = "velocity x";
    [SerializeField] private string velocity_z_key = "velocity z";

    public void SetVelocity(float x, float z)
    {
        anim.SetFloat(velocity_x_key, x, 0.1f, Time.deltaTime);
        anim.SetFloat(velocity_z_key, z, 0.1f, Time.deltaTime);
    }
}
