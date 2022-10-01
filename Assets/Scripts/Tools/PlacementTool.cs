using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

[RequireComponent(typeof(LaserPointer))]
public abstract class PlacementTool : BaseTool
{
    protected List<GameObject> spawners = new List<GameObject>();
    protected Vector3 firstSpawnerPos, lastSpawnerPos;
    protected GameObject firstSpawnerBlock, lastSpawnerBlock;

    public GameObject spawnerPrefab;
    public SteamVR_Action_Boolean action;

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void OnDestroy()
    {
        DestroyAllSpawners();
    }

    protected GameObject CreateSpawner(Vector3 pos, bool addToSpawnerList = true)
    {
        var newSpawner = Instantiate(spawnerPrefab, pos, Quaternion.identity);
        if (addToSpawnerList) spawners.Add(newSpawner);

        Debug.Log($"Created spawner at {pos}");
        return newSpawner;
    }

    protected void MoveSpawner(GameObject spawner, Vector3 newPos)
    {
        spawner.transform.position = newPos;
    }

    protected void DestroyAllSpawners()
    {
        if (spawners != null)
        {
            foreach (GameObject spawner in spawners)
            {
                Destroy(spawner);
            }
        }

        Destroy(firstSpawnerBlock);
        Destroy(lastSpawnerBlock);

        spawners = new List<GameObject>();
    }
}