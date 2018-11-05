using UnityEngine;

using System.Collections.Generic;

public class Chunk : MonoBehaviour
{
    public bool Loaded { get; set; }
    public bool Dirty { get; set; }
    public bool isAir { get; set; }
    
    private List<Vector3> vertices;
    private List<int> triangles;
    private byte[,,] blocks = null;
    private MeshRenderer meshRenderer;
    private MeshFilter meshFilter;

    public void Unload()
    {
        Dirty = true;
        meshFilter.mesh.Clear();
    }

    public Chunk Create()
    {
        Dirty = true;
        Loaded = false;
        isAir = false;
        blocks = new byte[16, 16, 16];
        vertices = new List<Vector3>();
        triangles = new List<int>();

        meshRenderer = gameObject.AddComponent<MeshRenderer>();
        meshFilter = gameObject.AddComponent<MeshFilter>();
        meshRenderer.material = new Material(Shader.Find("Diffuse")); // just to get rid of ugly default color

        name = "Chunk:" + transform.position.ToString();
        return this;
    }

    public void SetBlock(int x, int y, int z, byte value)
    {
        blocks[x, y, z] = value;
        Dirty = true;
    }

    public bool IsAirChunk()
    {
        for (int x = 0; x < 16; ++x)
        {
            for (int y = 0; y < 16; ++y)
            {
                for (int z = 0; z < 16; ++z)
                {
                    if (blocks[x, y, z] != 0)
                    {
                        return false;
                    }
                }
            }
        }

        return true;
    }

    public void Rebuild()
    {
        vertices.Clear();
        triangles.Clear();

        Dirty = false;

        isAir = IsAirChunk();

        if (isAir)
            return;

        for (int x = 0; x < 16; ++x)
        {
            for (int y = 0; y < 16; ++y)
            {
                for (int z = 0; z < 16; ++z)
                {
                    byte block = blocks[x, y, z];
                    int vertexIndex = 0;
                    byte top = y == 16 - 1 ? (byte) 0 : blocks[x, y + 1, z];
                    byte bottom = y == 0 ? (byte) 0 : blocks[x, y - 1, z];
                    byte north = z == 16 - 1 ? (byte) 0 : blocks[x, y, z + 1];
                    byte south = z == 0 ? (byte) 0 : blocks[x, y, z - 1];
                    byte east = x == 16 - 1 ? (byte) 0 : blocks[x + 1, y, z];
                    byte west = x == 0 ? (byte) 0 : blocks[x - 1, y, z];

                    if (block != 0 && top == 0)
                    {
                        vertexIndex = vertices.Count;
                        vertices.Add(new Vector3(x, y + 1, z));
                        vertices.Add(new Vector3(x, y + 1, z + 1));
                        vertices.Add(new Vector3(x + 1, y + 1, z + 1));
                        vertices.Add(new Vector3(x + 1, y + 1, z));
                        
                        triangles.Add(vertexIndex);
                        triangles.Add(vertexIndex + 1);
                        triangles.Add(vertexIndex + 2);
                        
                        triangles.Add(vertexIndex + 2);
                        triangles.Add(vertexIndex + 3);
                        triangles.Add(vertexIndex);
                    }

                    if (block != 0 && north == 0)
                    {
                        vertexIndex = vertices.Count;
                        vertices.Add(new Vector3(x, y, z + 1));
                        vertices.Add(new Vector3(x + 1, y, z + 1));
                        vertices.Add(new Vector3(x + 1, y + 1, z + 1));
                        vertices.Add(new Vector3(x, y + 1, z + 1));
                        
                        triangles.Add(vertexIndex);
                        triangles.Add(vertexIndex + 1);
                        triangles.Add(vertexIndex + 2);
                        
                        triangles.Add(vertexIndex + 2);
                        triangles.Add(vertexIndex + 3);
                        triangles.Add(vertexIndex);
                    }

                    if (block != 0 && east == 0)
                    {
                        vertexIndex = vertices.Count;
                        vertices.Add(new Vector3(x + 1, y, z));
                        vertices.Add(new Vector3(x + 1, y + 1, z));
                        vertices.Add(new Vector3(x + 1, y + 1, z + 1));
                        vertices.Add(new Vector3(x + 1, y, z + 1));
                        
                        triangles.Add(vertexIndex);
                        triangles.Add(vertexIndex + 1);
                        triangles.Add(vertexIndex + 2);
                        
                        triangles.Add(vertexIndex + 2);
                        triangles.Add(vertexIndex + 3);
                        triangles.Add(vertexIndex);
                    }

                    if (block != 0 && south == 0)
                    {
                        vertexIndex = vertices.Count;
                        vertices.Add(new Vector3(x, y, z));
                        vertices.Add(new Vector3(x, y + 1, z));
                        vertices.Add(new Vector3(x + 1, y + 1, z));
                        vertices.Add(new Vector3(x + 1, y, z));
                        
                        triangles.Add(vertexIndex);
                        triangles.Add(vertexIndex + 1);
                        triangles.Add(vertexIndex + 2);
                        
                        triangles.Add(vertexIndex + 2);
                        triangles.Add(vertexIndex + 3);
                        triangles.Add(vertexIndex);
                    }

                    if (block != 0 && west == 0)
                    {
                        vertexIndex = vertices.Count;
                        vertices.Add(new Vector3(x, y, z + 1));
                        vertices.Add(new Vector3(x, y + 1, z + 1));
                        vertices.Add(new Vector3(x, y + 1, z));
                        vertices.Add(new Vector3(x, y, z));
                        
                        triangles.Add(vertexIndex);
                        triangles.Add(vertexIndex + 1);
                        triangles.Add(vertexIndex + 2);
                        
                        triangles.Add(vertexIndex + 2);
                        triangles.Add(vertexIndex + 3);
                        triangles.Add(vertexIndex);
                    }

                    if (block != 0 && bottom == 0)
                    {
                        vertexIndex = vertices.Count;
                        vertices.Add(new Vector3(x, y, z));
                        vertices.Add(new Vector3(x + 1, y, z));
                        vertices.Add(new Vector3(x + 1, y, z + 1));
                        vertices.Add(new Vector3(x, y, z + 1));
                        
                        triangles.Add(vertexIndex);
                        triangles.Add(vertexIndex + 1);
                        triangles.Add(vertexIndex + 2);
                        
                        triangles.Add(vertexIndex + 2);
                        triangles.Add(vertexIndex + 3);
                        triangles.Add(vertexIndex);
                    }
                }
            }
        }

        var mesh = meshFilter.mesh;
        mesh.Clear();
        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();
        mesh.Optimize();
        mesh.RecalculateNormals();
    }
}