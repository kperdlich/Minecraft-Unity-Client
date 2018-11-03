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

    public override Packet Read(BinaryReader reader)
    {
        x = reader.ReadInt32();
        z = reader.ReadInt32();
        mode = reader.ReadBoolean();
        return base.Read(reader);
    }
}
