using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class TurnWithTouchpad : MonoBehaviour
{
    public SteamVR_Action_Boolean turnLeftAction;
    public SteamVR_Action_Boolean turnRightAction;
    public SteamVR_Input_Sources handType;
    public float rotationSpeed;

    private Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = transform.root.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (turnLeftAction.GetStateDown(handType))
        {
            Rotate(Vector2.left);
        }
        else if (turnRightAction.GetStateDown(handType))
        {
            Rotate(Vector3.right);
        }
    }

    void Rotate(Vector2 direction)
    {
        playerTransform.Rotate(Vector3.up * direction.x * rotationSpeed);
    }
}
