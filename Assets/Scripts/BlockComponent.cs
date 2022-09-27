using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class BlockComponent : MonoBehaviour
{
    private Block _block;
    private MeshFilter _filter;

    private void Start()
    {
        _filter = GetComponent<MeshFilter>();

        var blockPosition = new Vector3()
        {
            x = Mathf.Round(transform.position.x),
            y = Mathf.Round(transform.position.y),
            z = Mathf.Round(transform.position.z)
        };

        _block = BlockManager.SpawnBlock(blockPosition);
    }

    private void Update()
    {
        _block.UpdateBlock();

        _filter.mesh = _block.Mesh;
        transform.position = _block.Position;
    }

    /// <summary>
    /// Notify the block that it is being destroyed
    /// </summary>
    private void OnDestroy()
    {
        _block.Destroy();
    }
}
