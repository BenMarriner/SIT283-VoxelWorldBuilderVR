using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerUIManager : MonoBehaviour
{
    private ToolManager _toolManager;
    
    public ControlLabel menuLabel;
    public ControlLabel trackpadLabel;
    public ControlLabel currentToolLabel;

    // Start is called before the first frame update
    void Start()
    {
        _toolManager = transform.parent.GetComponentInChildren<ToolManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //ScurrentToolLabel.labelString = _toolManager.currentTool.name;
    }
}
