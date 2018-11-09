using UnityEngine;
using System.Collections.Generic;

public class Chunk : MonoBehaviour
{
    public bool Loaded;
    public bool Dirty;
    public bool isAir;
    
    private List<Vector3> vertices;
    private List<int> triangles;
    private List<Color> colors;
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
        colors = new List<Color>();

        meshRenderer = gameObject.AddComponent<MeshRenderer>();
        meshFilter = gameObject.AddComponent<MeshFilter>();
        meshRenderer.material = Resources.Load("materials/BlockMaterial", typeof(Material)) as Material;
        transform.rotation = Quaternion.Euler(270f, 0f, 0f);
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
        colors.Clear();

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

                    if (block == 0)
                        continue;

                    int vertexIndex = 0;
                    byte top = y == 16 - 1 ? (byte) 0 : blocks[x, y + 1, z];
                    byte bottom = y == 0 ? (byte) 0 : blocks[x, y - 1, z];
                    byte north = z == 16 - 1 ? (byte) 0 : blocks[x, y, z + 1];
                    byte south = z == 0 ? (byte) 0 : blocks[x, y, z - 1];
                    byte east = x == 16 - 1 ? (byte) 0 : blocks[x + 1, y, z];
                    byte west = x == 0 ? (byte) 0 : blocks[x - 1, y, z];

                    if (top == 0)
                    {
                        vertexIndex = vertices.Count;
                        vertices.Add(new Vector3(x, y + 1, z));
                        vertices.Add(new Vector3(x, y + 1, z + 1));
                        vertices.Add(new Vector3(x + 1, y + 1, z + 1));
                        vertices.Add(new Vector3(x + 1, y + 1, z));

                        AddColors(block, 4);

                        triangles.Add(vertexIndex);
                        triangles.Add(vertexIndex + 1);
                        triangles.Add(vertexIndex + 2);
                        
                        triangles.Add(vertexIndex + 2);
                        triangles.Add(vertexIndex + 3);
                        triangles.Add(vertexIndex);
                    }

                    if (north == 0)
                    {
                        vertexIndex = vertices.Count;
                        vertices.Add(new Vector3(x, y, z + 1));
                        vertices.Add(new Vector3(x + 1, y, z + 1));
                        vertices.Add(new Vector3(x + 1, y + 1, z + 1));
                        vertices.Add(new Vector3(x, y + 1, z + 1));

                        AddColors(block, 4);

                        triangles.Add(vertexIndex);
                        triangles.Add(vertexIndex + 1);
                        triangles.Add(vertexIndex + 2);
                        
                        triangles.Add(vertexIndex + 2);
                        triangles.Add(vertexIndex + 3);
                        triangles.Add(vertexIndex);
                    }

                    if (east == 0)
                    {
                        vertexIndex = vertices.Count;
                        vertices.Add(new Vector3(x + 1, y, z));
                        vertices.Add(new Vector3(x + 1, y + 1, z));
                        vertices.Add(new Vector3(x + 1, y + 1, z + 1));
                        vertices.Add(new Vector3(x + 1, y, z + 1));

                        AddColors(block, 4);

                        triangles.Add(vertexIndex);
                        triangles.Add(vertexIndex + 1);
                        triangles.Add(vertexIndex + 2);
                        
                        triangles.Add(vertexIndex + 2);
                        triangles.Add(vertexIndex + 3);
                        triangles.Add(vertexIndex);
                    }

                    if (south == 0)
                    {
                        vertexIndex = vertices.Count;
                        vertices.Add(new Vector3(x, y, z));
                        vertices.Add(new Vector3(x, y + 1, z));
                        vertices.Add(new Vector3(x + 1, y + 1, z));
                        vertices.Add(new Vector3(x + 1, y, z));

                        AddColors(block, 4);

                        triangles.Add(vertexIndex);
                        triangles.Add(vertexIndex + 1);
                        triangles.Add(vertexIndex + 2);
                        
                        triangles.Add(vertexIndex + 2);
                        triangles.Add(vertexIndex + 3);
                        triangles.Add(vertexIndex);
                    }

                    if (west == 0)
                    {
                        vertexIndex = vertices.Count;
                        vertices.Add(new Vector3(x, y, z + 1));
                        vertices.Add(new Vector3(x, y + 1, z + 1));
                        vertices.Add(new Vector3(x, y + 1, z));
                        vertices.Add(new Vector3(x, y, z));

                        AddColors(block, 4);

                        triangles.Add(vertexIndex);
                        triangles.Add(vertexIndex + 1);
                        triangles.Add(vertexIndex + 2);
                        
                        triangles.Add(vertexIndex + 2);
                        triangles.Add(vertexIndex + 3);
                        triangles.Add(vertexIndex);
                    }

                    if (bottom == 0)
                    {
                        vertexIndex = vertices.Count;
                        vertices.Add(new Vector3(x, y, z));
                        vertices.Add(new Vector3(x + 1, y, z));
                        vertices.Add(new Vector3(x + 1, y, z + 1));
                        vertices.Add(new Vector3(x, y, z + 1));

                        AddColors(block, 4);

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
        mesh.colors = colors.ToArray();
        mesh.Optimize();
        mesh.RecalculateNormals();
    }

    private void AddColors(byte blockId, int amount)
    {
        Color c;
        switch (blockId)
        {
            case 4:
                c = new Color(190f, 190f, 190f); // STONE
                break;
            case 2:
                c = new Color(92.0f, 141.0f, 94.0f); // GRASS
                break;
            case 3:
                c = new Color(150.0f, 102.0f, 0.0f); // DIRT
                break;
            case 17:
                c = new Color(111f, 81f, 0f); // Oak Wood
                break;
            case 5:
                c = new Color(169f, 108f, 0f); // Oak Wood Plank
                break;
            case 18:
                c = new Color(9f, 108f, 0f); // Oak Leaves
                break;
            default:
                c = new Color(255.0f, 134.0f, 255.0f);
                break;
        }

        for (int i = 0; i < amount; ++i)
        {
            colors.Add(c);
        }
    }
}