using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Valve.Newtonsoft.Json;

public class Block
{
    private Mesh _mesh;
    private bool[] _visibleFaces = new bool[6];
    private Block[] _neighbouringBlocks = new Block[6];
    private Vector3 _position;

    public Mesh Mesh { get { return _mesh; } }
    public bool[] VisibleFaces { get { return _visibleFaces; } }
    public Block[] NeighbouringBlocks { get { return _neighbouringBlocks; } }
    public Vector3 Position { get { return _position; } }
    public bool IsFullyOccluded
    {
        get
        {
            foreach (bool visibleFace in _visibleFaces)
            {
                if (visibleFace) return false;
            }
            return true;
        }
    }

    public Block(bool[] visibleFaces, Vector3 pos)
    {
        _mesh = BlockFactory.GenerateMesh(visibleFaces);
        _visibleFaces = visibleFaces;
        _position = pos;
    }

    public void UpdateBlock()
    {
        _neighbouringBlocks = BlockManager.GetNeighbouringBlocks(_position);
        
        for (int i = 0; i < _neighbouringBlocks.Length; i++)
        {
            // Show the face if there is no neighbouring block covering a particular side
            _visibleFaces[i] = _neighbouringBlocks[i] == null;
        }

        _mesh = BlockFactory.GenerateMesh(_visibleFaces);
    }

    public void Destroy()
    {
        BlockManager.DestroyBlock(this);
    }
}