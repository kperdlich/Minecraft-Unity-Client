using UnityEngine;
using System.Collections;
using System.IO;

public class PacketBlockChange : Packet {

    public static readonly byte ID = 0x35;

    public int x, z;
    public byte y, blockType, blockMetadata;

    public PacketBlockChange() : base(ID)
    {
    }

    public override void Action(BinaryWriter writer)
    {
        base.Action(writer);
        var chunk = ChunkManager.Get().GetChunk(new Vector3(x, y, z));
    }

    public override Packet Read(BinaryReader reader)
    {
        base.Read(reader);
        x = reader.ReadInt32();
        y = reader.ReadByte();
        z = reader.ReadInt32();
        blockType = reader.ReadByte();
        blockMetadata = reader.ReadByte();
        return this;
    }
}
