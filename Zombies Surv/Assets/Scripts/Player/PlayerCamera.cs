using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private LayerMask fadeLayerMask;
    [SerializeField] private Vector3 cameraOffset;

    private Camera rtsCamera;
    private Fader fadeObject;

    private void Start()
    {
        rtsCamera = GetComponent<Camera>();
    }

    private void Update()
    {
        RtsCamera();
        FadeObjectBetweenPlayer();
    }

    private void RtsCamera()
    {
        rtsCamera.transform.position = player.position + cameraOffset;
    }

    private void FadeObjectBetweenPlayer()
    {
        Ray ray = new Ray(rtsCamera.transform.position, (player.position - transform.position));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 999, fadeLayerMask) && hit.collider)
        {
            Fader l_fadeObject = hit.collider.gameObject.GetComponent<Fader>();

            if (l_fadeObject)
            {
                if (fadeObject && fadeObject != l_fadeObject)
                {
                    fadeObject.StopFade();
                }

                fadeObject = l_fadeObject;
                fadeObject.Fade();
            }
        }
        else if (fadeObject)
        {
            fadeObject.StopFade();
            fadeObject = null;
        }
    }

    private void OnDrawGizmos()
    {
       // Gizmos.DrawRay(transform.position, transform.TransformDirection(player.position) * 10);
        Gizmos.DrawRay(transform.position, (player.position - transform.position) * 10);
    }
}
