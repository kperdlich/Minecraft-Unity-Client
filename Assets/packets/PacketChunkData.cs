using UnityEngine;
using System.Collections;
using System.IO;

public class PacketChunkData : Packet
{
    public static readonly byte ID = 0x33;
    private int x = 0, z = 0;
    private bool groundUpContinuous = false;
    private ushort primaryBitMap = 0, addBitMap = 0;
    private int compressedSize = 0, unusedInt = 0;
    private byte[] compressedData = null;

    public PacketChunkData() : base(ID)
    {
    }

    public override void Action(BinaryWriter writer)
    {
        base.Action(writer);
    }

    public override Packet Read(BinaryReader reader)
    {
        x = reader.ReadInt32();
        z = reader.ReadInt32();
        groundUpContinuous = reader.ReadBoolean();
        primaryBitMap = reader.ReadUInt16();
        addBitMap = reader.ReadUInt16();
        compressedSize = reader.ReadInt32();
        unusedInt = reader.ReadInt32();
        compressedData = reader.ReadBytes(compressedSize);
        return base.Read(reader);
    }
}
