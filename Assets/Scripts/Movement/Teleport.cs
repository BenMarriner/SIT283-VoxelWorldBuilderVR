using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

[RequireComponent(typeof(LaserPointer))]
public class Teleport : MovementBehaviour
{
    private LaserPointer pointer;
    private Vector3 teleportPosition;
    GameObject playerCamera;

    protected override void Start()
    {
        base.Start();
        pointer = GetComponent<LaserPointer>();
        playerCamera = cameraRig.transform.Find("Camera").gameObject;
    }

    // Update is called once per frame
    protected override void Update()
    {
        if (movementTypeEnabled)
        {
            if (moveAction.GetStateUp(handType))
            {
                Vector3 playerCameraOffset = new Vector3
                {
                    x = playerCamera.transform.localPosition.x,
                    y = 0,
                    z = playerCamera.transform.localPosition.z
                };

                if (pointer.hit.collider)
                {
                    teleportPosition = pointer.hit.point - playerCameraOffset;
                    player.transform.position = teleportPosition;
                }
            }
        }
    }
}
