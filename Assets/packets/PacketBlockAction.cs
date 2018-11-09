using UnityEngine;
using System.Collections;
using System.IO;

public class PacketBlockAction : Packet
{
    public static readonly byte ID = 0x36;

    public int x, z;
    public short y;
    public byte byte1, byte2;

    public PacketBlockAction() : base(ID)
    {
    }

    public override Packet Read(BinaryReader reader)
    {
        x = reader.ReadInt32();
        y = reader.ReadInt16();
        z = reader.ReadInt32();
        byte1 = reader.ReadByte();
        byte2 = reader.ReadByte();
        return base.Read(reader);
    }
}
