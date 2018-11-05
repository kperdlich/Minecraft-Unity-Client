using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using Ionic.Zip;

public class Chunk : MonoBehaviour
{
    public bool Loaded = false, Dirty = true, isAir = false;

    private readonly int SIZE = 16;
    private List<GameObject> blockList;

    private byte[,,] blocks = null;

    public void Unload()
    {
        Dirty = true;

        for (int i = 0; i < blocks.Length; i++)
        {
            Destroy(blockList[i]);
        }

        blockList.Clear();
    }

    public Chunk Create()
    {
        Dirty = true;
        Loaded = false;
        blocks = new byte[16, 16, 16];
        blockList = new List<GameObject>();

        /*meshRenderer = gameObject.AddComponent<MeshRenderer>();
        meshFilter = gameObject.AddComponent<MeshFilter>();
        meshRenderer.material = new Material(Shader.Find("Diffuse")); // just to get rid of ugly default color
        */
        name = "Chunk:" + transform.position.ToString();
        return this;

        /*Vector3[] vertices = {
            new Vector3 (0, 0, 0),
            new Vector3 (SIZE, 0, 0),
            new Vector3 (SIZE, SIZE, 0),
            new Vector3 (0, SIZE, 0),
            new Vector3 (0, SIZE, SIZE),
            new Vector3 (SIZE, SIZE, SIZE),
            new Vector3 (SIZE, 0, SIZE),
            new Vector3 (0, 0, SIZE),
        };

        int[] triangles = {
            0, 2, 1, //face front
			0, 3, 2,
            2, 3, 4, //face top
			2, 4, 5,
            1, 2, 5, //face right
			1, 5, 6,
            0, 7, 4, //face left
			0, 4, 3,
            5, 4, 7, //face back
			5, 7, 6,
            0, 6, 7, //face bottom
			0, 1, 6
        };

        meshRenderer = gameObject.AddComponent<MeshRenderer>();                
        meshFilter = gameObject.AddComponent<MeshFilter>();

        var mesh = meshFilter.mesh;
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.Optimize();
        mesh.RecalculateNormals();*/
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

    private void AddBlock(int x, int y, int z)
    {
        var obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
        obj.transform.position = new Vector3(transform.position.x + x, transform.position.y + y, transform.position.z + z);
        obj.transform.parent = transform;
        obj.name = string.Format("Block:{0},{1},{2}", x, y, z);
        blockList.Add(obj);
    }

    public void Rebuild()
    {
        const int BLOCK_SIZE = 1;

        var verticesList = new List<Vector3>();
        var trianglesList = new List<int>();
        int blockCounter = 0;

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
                    if (blocks[x, y, z] == 0)
                        continue;

                    if (x == 0 || y == 0 || z == 0 || x == 15 || y == 15 || z == 15)
                    {
                        AddBlock(x, y, z);
                    }
                    else if (blocks[x - 1, y, z] == 0 || blocks[x + 1, y, z] == 0 ||
                        blocks[x, y - 1, z] == 0 || blocks[x, y + 1, z] == 0 ||
                        blocks[x, y, z - 1] == 0 || blocks[x, y, z + 1] == 0)
                    {
                        AddBlock(x, y, z);
                    }

                    /*Vector3[] vertices = {
                        new Vector3 (0 + x, 0 + y, 0 + z),
                        new Vector3 (BLOCK_SIZE + x, 0 + y, 0 + z),
                        new Vector3 (BLOCK_SIZE + x, BLOCK_SIZE + y, 0 + z),
                        new Vector3 (0+x , BLOCK_SIZE+y, 0+z),
                        new Vector3 (0+x, BLOCK_SIZE+y, BLOCK_SIZE+z),
                        new Vector3 (BLOCK_SIZE+x, BLOCK_SIZE+y, BLOCK_SIZE+z),
                        new Vector3 (BLOCK_SIZE+x, 0+y, BLOCK_SIZE+z),
                        new Vector3 (0+x, 0+y, BLOCK_SIZE+z),
                    };

                    int[] triangles = {
                        0 + blockCounter, 2 + blockCounter, 1 + blockCounter, //face front
                        0 + blockCounter, 3 + blockCounter, 2 + blockCounter,
                        2 + blockCounter, 3 + blockCounter, 4 + blockCounter, //face top
                        2 + blockCounter, 4 + blockCounter, 5 + blockCounter,
                        1 + blockCounter, 2 + blockCounter, 5 + blockCounter, //face right
                        1 + blockCounter, 5 + blockCounter, 6 + blockCounter,
                        0 + blockCounter, 7 + blockCounter, 4 + blockCounter, //face left
                        0 + blockCounter, 4 + blockCounter, 3 + blockCounter,
                        5 + blockCounter, 4 + blockCounter, 7 + blockCounter, //face back
                        5 + blockCounter, 7 + blockCounter, 6 + blockCounter,
                        0 + blockCounter, 6 + blockCounter, 7 + blockCounter, //face bottom
                        0 + blockCounter, 1 + blockCounter, 6 + blockCounter
                    };*/

                    //verticesList.AddRange(vertices);
                    //trianglesList.AddRange(triangles);

                    //blockCounter++;
                }
            }
        }

        /*var mesh = meshFilter.mesh;
        mesh.Clear();
        mesh.vertices = verticesList.ToArray();
        mesh.triangles = trianglesList.ToArray();
        mesh.Optimize();
        mesh.RecalculateNormals();*/
    }
}
