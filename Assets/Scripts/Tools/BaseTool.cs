using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public abstract class BaseTool : MonoBehaviour
{
    protected LaserPointer _pointer;
    protected Vector3 roundedPosition;
    public SteamVR_ActionSet toolActionSet;
    public SteamVR_Input_Sources handType;

    protected virtual void Start()
    {
        _pointer = GetComponent<LaserPointer>();
    }

    protected virtual void Update()
    {
        roundedPosition = new Vector3()
        {
            x = Mathf.Round(_pointer.endPosition.x),
            y = Mathf.Round(_pointer.endPosition.y),
            z = Mathf.Round(_pointer.endPosition.z)
        };
    }

    protected abstract void OnDestroy();
}
