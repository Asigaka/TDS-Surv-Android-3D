using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshOutline))]
public abstract class Interactable : MonoBehaviour
{
    private const MeshOutline.Mode mode = MeshOutline.Mode.OutlineAndSilhouette;
    private const float outlineWidth = 8;

    private MeshOutline outline;

    private void Awake()
    {
        outline = GetComponent<MeshOutline>();
        outline.OutlineMode = mode;
        outline.OutlineWidth = outlineWidth;

        OnInvisible();
    }

    public virtual void OnVisible()
    {
        outline.enabled = true;
    }

    public virtual void OnInvisible()
    {
        outline.enabled = false;
    }

    public abstract void Interactive();
}
