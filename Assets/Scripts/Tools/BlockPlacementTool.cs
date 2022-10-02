using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Valve.VR;

[RequireComponent(typeof(LaserPointer))]
public class BlockPlacementTool : PlacementTool
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        CreateSpawner(_pointer.endPosition);
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        spawners[0].transform.position = roundedPosition;

        if (action.GetStateDown(handType))
        {
            spawners[0].GetComponent<BlockSpawner>().Spawn();
        }
    }

    protected override void OnDestroy()
    {
        Destroy(spawners[0]);
    }
}
