using UnityEngine;
using System.Collections;
using System.IO;

public class PacketTimeUpdate : Packet
{
    public static readonly byte ID = 0x04;
    private long time = 0L;

    public PacketTimeUpdate() : base(ID)
    {
    }

    public override Packet Read(BinaryReader reader)
    {
        time = reader.ReadInt64();
        return base.Read(reader);
    }
}
