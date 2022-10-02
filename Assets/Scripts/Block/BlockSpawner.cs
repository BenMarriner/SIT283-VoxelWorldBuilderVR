using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class BlockSpawner : MonoBehaviour
{
    private GameObject _currBlock;
    private Vector3 _roundedPosition;

    public GameObject blockPrefab;
    public bool spawnCubeOnStart = true;
    
    // Start is called before the first frame update
    void Start()
    {
        if (spawnCubeOnStart) Spawn();
    }

    public void Spawn()
    {
        _roundedPosition = new Vector3()
        {
            x = Mathf.Round(transform.position.x),
            y = Mathf.Round(transform.position.y),
            z = Mathf.Round(transform.position.z)
        };
        transform.position = _roundedPosition;

        // Check for existing block at location
        var block = BlockManager.GetBlockAtPosition(_roundedPosition);
        if (block != null)
            _currBlock = block.Component.gameObject;
        else
            _currBlock = null;

        if (!_currBlock)
            _currBlock = Instantiate(blockPrefab, _roundedPosition, Quaternion.identity);
        else
            Destroy(_currBlock);
    }
}
