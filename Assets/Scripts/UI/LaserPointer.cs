using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using Valve.VR;

[RequireComponent(typeof(LineRenderer))]
public class LaserPointer : MonoBehaviour
{
    private LineRenderer _lineRenderer;
    private float _minTraceDistance = 1.0f, _maxTraceDistance = 100.0f;

    public float traceDistance = 100.0f;
    public Color color;
    [HideInInspector]
    public RaycastHit hit;
    [HideInInspector]
    public Vector3 endPosition;
    public SteamVR_Action_Vector2 scrollAction;
    public float scrollSpeed = 1.0f;
    public SteamVR_Input_Sources handType;

    // Start is called before the first frame update
    void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        traceDistance += scrollAction.GetAxis(handType).y * scrollSpeed;
        traceDistance = Mathf.Clamp(traceDistance, _minTraceDistance, _maxTraceDistance);
        
        hit = Trace();
        endPosition = transform.forward * traceDistance + transform.position;

        if (hit.collider)
        {
            endPosition = hit.point;
        }

        _lineRenderer.SetPosition(0, transform.position);
        _lineRenderer.SetPosition(1, endPosition);
        _lineRenderer.material.color = color;
    }

    private RaycastHit Trace()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        Physics.Raycast(ray, out hit, traceDistance);
        return hit;
    }
}
