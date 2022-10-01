using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ToolManager : MonoBehaviour
{
    private SteamVR_ActionSet _currActionSet;

    public SteamVR_Input_Sources handType;
    [HideInInspector]
    public BaseTool currentTool;

    // Start is called before the first frame update
    void Start()
    {
        // Temporary
        ChangeTool(GetComponent<RectanglePlacementTool>());
    }

    // Update is called once per frame
    void Update()
    {

    }

    void ChangeTool(BaseTool tool)
    {
        Destroy(currentTool);

        currentTool = tool;
        currentTool.handType = handType;
        _currActionSet = tool.toolActionSet;
        _currActionSet.Activate(handType, 2, false);
    }
}
