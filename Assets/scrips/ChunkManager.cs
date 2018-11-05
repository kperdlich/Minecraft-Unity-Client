using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChunkManager : MonoBehaviour
{
    public static int LoadedChunks { get; set; }
    private static ChunkManager instance;
    private Dictionary<Vector2, ChunkColumn> map;

    void Start()
    {
        map = new Dictionary<Vector2, ChunkColumn>();
        instance = this;
    }


    public Chunk GetChunk(Vector3 pos)
    {
        ChunkColumn cc;
        if (map.TryGetValue(new Vector2(pos.x, pos.z), out cc))
        {
            return cc.Chunks[(int) pos.y / 16];                        
        }
        return null;
    }

    public ChunkColumn CreateChunkColumn(Vector2 pos)
    {
        var obj = new GameObject();   
        var cc = obj.AddComponent<ChunkColumn>().Create(pos);        
        map.Add(pos, cc);
        return cc;
    }

    public static ChunkManager Get()
    {
        if (!instance)
        {
            Debug.LogError("ChunkManager not placed in world!");             
        }
        return instance;
    }
}
