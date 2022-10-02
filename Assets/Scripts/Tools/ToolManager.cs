using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ToolManager : MonoBehaviour
{
    public SteamVR_Input_Sources handType;
    [HideInInspector]
    public BaseTool currentTool;

    // Start is called before the first frame update
    void Start()
    {
        ChangeTool(GetComponent<BlockPlacementTool>());
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
        tool.toolActionSet.Activate(handType, 2, false);
    }
}
