using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class BlockSpawner : MonoBehaviour
{
    public GameObject blockPrefab;
    public Vector3 dimensions;
    
    // Start is called before the first frame update
    void Start()
    {
        for (int x = 0; x < dimensions.x; x++)
        {
            for (int y = 0; y < dimensions.y; y++)
            {
                for (int z = 0; z < dimensions.z; z++)
                {
                    var coords = new Vector3(x, y, z);
                    Instantiate(blockPrefab, coords, Quaternion.identity);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
