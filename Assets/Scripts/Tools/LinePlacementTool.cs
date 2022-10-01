using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;
using Valve.VR.InteractionSystem;

[RequireComponent(typeof(LaserPointer))]
public class LinePlacementTool : PlacementTool
{
    protected override void Update()
    {
        base.Update();

        Debug.Log($"First spawner location: {firstSpawnerPos}");
        Debug.Log($"Last spawner location: {lastSpawnerPos}");

        // When player pushes button, create the last spawner
        if (action.GetStateDown(handType))
        {
            lastSpawnerBlock = CreateSpawner(roundedPosition, false);
        }
        // While the player is holding the button, track the last spawner position and draw rectangle
        else if (action.GetState(handType))
        {
            // Destroy old spawners
            foreach (var spawner in spawners) Destroy(spawner);

            // Move last spawner to a new position
            MoveSpawner(lastSpawnerBlock, roundedPosition);
            lastSpawnerPos = lastSpawnerBlock.transform.position;

            // Create square
            CreateLineOfSpawners(firstSpawnerPos, lastSpawnerPos);
        }
        // When the player lets go of the button, spawn cubes and destroy all spawners
        else if (action.GetStateUp(handType))
        {
            // Spawn blocks
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
        // When the player isn't holding the button, move the first block around
        else
        {
            if (!firstSpawnerBlock) firstSpawnerBlock = CreateSpawner(roundedPosition, false);
            else                    MoveSpawner(firstSpawnerBlock, roundedPosition);

            firstSpawnerPos = firstSpawnerBlock.transform.position;
        }
    }

    private void CreateLineOfSpawners(Vector3 startPos, Vector3 endPos)
    {
        var heading = endPos - startPos;
        var distance = heading.magnitude;
        var cubeSize = 1.0f;
        var numSpawners = (int)(distance / cubeSize);
        GameObject[] spawners = new GameObject[numSpawners]; 

        for (int i = 0; i < numSpawners; i++)
        {
            // Location between start and end positions
            var spawnerPos = Vector3.Lerp(startPos, endPos, (i + 1) / (float)numSpawners);
            // Rounding
            spawnerPos = new Vector3()
            {
                x = Mathf.Round(spawnerPos.x),
                y = Mathf.Round(spawnerPos.y),
                z = Mathf.Round(spawnerPos.z)
            };

            spawners[i] = Instantiate(spawnerPrefab, spawnerPos, Quaternion.identity);
        }

        base.spawners = new List<GameObject>(spawners);
    }
}