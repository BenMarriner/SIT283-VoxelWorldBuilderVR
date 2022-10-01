using System;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

[RequireComponent(typeof(LaserPointer))]
public class RectanglePlacementTool : PlacementTool
{
    protected override void Update()
    {
        base.Update();

        if (action.GetStateDown(handType))
        {
            lastSpawnerBlock = CreateSpawner(roundedPosition, false);
            lastSpawnerPos = roundedPosition;
        }
        else if (action.GetState(handType))
        {
            foreach (var spawner in spawners) Destroy(spawner);

            MoveSpawner(lastSpawnerBlock, roundedPosition);
            lastSpawnerPos = roundedPosition;

            CreateRectangleOfSpawners(firstSpawnerPos, lastSpawnerPos);
        }
        else if (action.GetStateUp(handType))
        {
            firstSpawnerBlock.GetComponent<BlockSpawner>().Spawn();
            foreach (var spawner in spawners)
            {
                spawner.GetComponent<BlockSpawner>().Spawn();
            }
            lastSpawnerBlock.GetComponent<BlockSpawner>().Spawn();

            DestroyAllSpawners();
            firstSpawnerBlock = null;
            firstSpawnerPos = default;
            lastSpawnerBlock = null;
            lastSpawnerPos = default;
        }
        else
        {
            if (!firstSpawnerBlock) firstSpawnerBlock = CreateSpawner(roundedPosition, false);
            else MoveSpawner(firstSpawnerBlock, roundedPosition);

            firstSpawnerPos = firstSpawnerBlock.transform.position;
        }
    }

    private void CreateRectangleOfSpawners(Vector3 startPos, Vector3 endPos)
    {
        for (int x = (int)startPos.x; x <= (int)endPos.x; x++)
        {
            for (int y = (int)startPos.y; y <= (int)endPos.y; y++)
            {
                CreateSpawner(new Vector3(x, (int)startPos.y, y));
            }
        }
    }
}