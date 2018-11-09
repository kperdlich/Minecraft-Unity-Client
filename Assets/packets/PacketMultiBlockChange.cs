using UnityEngine;
using System.Collections;
using System.IO;

public class PacketMultiBlockChange : Packet
{
    public static readonly byte ID = 0x34;

    public int x, z, dataSize;
    public short recordCount;
    public byte[] data;

    public PacketMultiBlockChange() : base(ID)
    {
    }

    public override void Action(BinaryWriter writer)
    {
        base.Action(writer);
        // todo
    }

    public override Packet Read(BinaryReader reader)
    {
        base.Read(reader);
        x = reader.ReadInt32();
        recordCount = reader.ReadInt16();
        z = reader.ReadInt32();
        dataSize = reader.ReadInt32();
        data = reader.ReadBytes(dataSize);
        return this;
    }
}
