using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public static class BlockFactory
{
    private static readonly Vector3 v0 = new Vector3(0.0f, 0.0f, 0.0f);
    private static readonly Vector3 v1 = new Vector3(1.0f, 0.0f, 0.0f);
    private static readonly Vector3 v2 = new Vector3(0.0f, 1.0f, 0.0f);
    private static readonly Vector3 v3 = new Vector3(1.0f, 1.0f, 0.0f);
    private static readonly Vector3 v4 = new Vector3(0.0f, 0.0f, 1.0f);
    private static readonly Vector3 v5 = new Vector3(1.0f, 0.0f, 1.0f);
    private static readonly Vector3 v6 = new Vector3(0.0f, 1.0f, 1.0f);
    private static readonly Vector3 v7 = new Vector3(1.0f, 1.0f, 1.0f);

    private static readonly Vector3[] vertices = new Vector3[]
    {
        // Back faces
        v0, v2, v3,
        v3, v1, v0,
        // Left faces
        v4, v6, v2,
        v2, v0, v4,
        // Right facecs
        v1, v3, v7,
        v7, v5, v1,
        // Front faces
        v4, v5, v7,
        v7, v6, v4,
        // Top faces
        v2, v6, v7,
        v7, v3, v2,
        // Bottom faces
        v0, v1, v5,
        v5, v4, v0
    };

    private static readonly int[] triangles = new int[]
    {
        // Back faces
        0, 1, 2,
        3, 4, 5,
        // Left Faces
        6, 7, 8,
        9, 10, 11,
        // Right Faces
        12, 13, 14,
        15, 16, 17,
        // Front Faces
        18, 19, 20,
        21, 22, 23,
        // Top Faces
        24, 25, 26,
        27, 28, 29,
        // Bottom Faces
        30, 31, 32,
        33, 34, 35
    };

    /// <summary>
    /// Selectively generates the faces of the cube
    /// </summary>
    /// <param name="faces"></param>
    private static int[] GenerateFaces(bool[] faces)
    {
        if (faces.Length != 6)
        {
            Debug.LogError($"Faces array parameter needs to contain a value for each face. Only got {faces.Length} values");
            return null;
        }
        
        int[] newFaces = new int[vertices.Length];
        
        for (int i = 0; i < faces.Length; i++)
        {
            if (faces[i])
            {
                for (int f = i * 6; f < (i + 1) * 6; f++)
                {
                    newFaces[f] = triangles[f];
                }
            }
        }

        return newFaces;
    }
    
    /// <summary>
    /// Generate the block mesh
    /// </summary>
    /// <param name="visibleFaces"></param>
    /// <returns></returns>
    public static Mesh GenerateMesh(bool[] visibleFaces)
    {
        // Construct the mesh
        Mesh mesh = new Mesh();
        mesh.name = "Block";
        mesh.SetVertices(vertices);

        var newFaces = GenerateFaces(visibleFaces);
        mesh.SetTriangles(newFaces, 0);

        mesh.RecalculateNormals();
        mesh.RecalculateTangents();
        mesh.RecalculateBounds();
        mesh.Optimize();
        return mesh;
    }

    /// <summary>
    /// Generates a block. Faces = { 0: Back, 1: Left, 2: Right, 3: Front, 4: Top, 5: Bottom }
    /// </summary>
    /// <param name="visibleFaces"></param>
    /// <returns></returns>
    public static Block GenerateBlock(bool[] visibleFaces, Vector3 position)
    {
        Block newBlock = new Block(visibleFaces, position);
        return newBlock;
    }
}
