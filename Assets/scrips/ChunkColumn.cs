using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChunkColumn : MonoBehaviour {

    [SerializeField]
    private bool Render = true;

    private Vector2 position;

    private List<Chunk> chunks;
    public List<Chunk> Chunks
    {
        get { return chunks; }
    }

    void FixedUpdate()
    {
        if (Render)
        {
            foreach (var chunk in chunks)
            {
                if (chunk.Loaded && chunk.Dirty)
                    chunk.Rebuild();
            }
        }
        else
        {
            foreach (var chunk in chunks)
            {
                if (chunk.Loaded && !chunk.Dirty)
                    chunk.Unload();
            }
        }
    }

    public ChunkColumn Create(Vector2 pos)
    {
        position = pos;
        chunks = new List<Chunk>();
        transform.position = new Vector3(pos.x * 16.0f, 0, pos.y * -16.0f);
        name = "ChunkColumn:" + transform.position.ToString();

        for (int i = 0; i < 16; ++i)
        {
            var obj = new GameObject();
            var c = obj.AddComponent<Chunk>();
            c.transform.parent = transform;
            c.transform.position = new Vector3(transform.position.x, i * 16.0f, transform.position.z);
            chunks.Add(c.Create());
        }
        
        return this;
    }	
}
