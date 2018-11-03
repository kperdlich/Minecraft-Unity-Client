using UnityEngine;
using System.Collections;
using System.IO;

public class PacketSpawnPosition : Packet
{
    public static readonly byte ID = 0x06;
    private int x, y, z;

    public PacketSpawnPosition() : base(ID)
    {
    }

    public override Packet Read(BinaryReader reader)
    {
        x = reader.ReadInt32();
        y = reader.ReadInt32();
        z = reader.ReadInt32();
        return this;
    }    
}

