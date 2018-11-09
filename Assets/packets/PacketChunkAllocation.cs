using UnityEngine;
using System.Collections;
using System.IO;

public class PacketChunkAllocation : Packet
{
    public static readonly byte ID = 0x32;
    private int x = 0, z = 0;
    private bool mode = false;

    public PacketChunkAllocation() : base(ID)
    {
    }

    public override void Action(BinaryWriter writer)
    {   
        if (mode)
        {
            ChunkManager.Get().CreateChunkColumn(new Vector2(x, z));
        }
        else
        {
            var c = ChunkManager.Get().GetChunk(new Vector2(x, z));
            if (c == null)
            {
               Debug.LogWarning("Packet: 0x32 - Couldn't find chunk: " + new Vector2(x, z).ToString());
            }

        }
    }

    public override Packet Read(BinaryReader reader)
    {
        x = reader.ReadInt32();
        z = reader.ReadInt32();
        mode = reader.ReadBoolean();
        return base.Read(reader);
    }
}
