using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BlockManager
{
    private static List<Block> _blocks = new List<Block>();

    public static Block SpawnBlock(Vector3 coords, BlockComponent component)
    {
        var newBlock = BlockFactory.GenerateBlock(new bool[] { true, true, true, true, true, true }, coords, component);
        _blocks.Add(newBlock);
        
        return newBlock;
    }

    /// <summary>
    /// Gets the blocks that are immediately adjacent to a specified position
    /// </summary>
    /// <param name="position"></param>
    /// <returns></returns>
    public static Block[] GetNeighbouringBlocks(Vector3 position)
    {
        Block[] neighbouringBlocks = new Block[6];

        for (int i = 0; i < neighbouringBlocks.Length; i++)
        {
            var neighbourPosition = position;
            switch (i)
            {
                case 0:
                    neighbourPosition.z += -1;
                    break;
                case 1:
                    neighbourPosition.x += -1;
                    break;
                case 2:
                    neighbourPosition.x += 1;
                    break;
                case 3:
                    neighbourPosition.z += 1;
                    break;
                case 4:
                    neighbourPosition.y += 1;
                    break;
                case 5:
                    neighbourPosition.y += -1;
                    break;
            }

            neighbouringBlocks[i] = GetBlockAtPosition(neighbourPosition);
        }

        return neighbouringBlocks;
    }

    /// <summary>
    /// Get the block at a particular position. Returns null if nothing is there
    /// or there are no blocks in the world.
    /// </summary>
    /// <param name="position"></param>
    /// <returns></returns>
    public static Block GetBlockAtPosition(Vector3 position)
    {
        if (_blocks.Count == 0) return null;
        return _blocks.Find(x => x.Position == position);
    }

    public static void DestroyBlock(Block block)
    {
        _blocks.Remove(block);
    }
}
