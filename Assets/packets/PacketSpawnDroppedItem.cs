using UnityEngine;
using System.Collections;
using System.IO;

public class PacketSpawnDroppedItem : Packet {

    public static readonly byte ID = 0x15;

    public PacketSpawnDroppedItem() : base(ID)
    {
    }

    public override void Action(BinaryWriter writer)
    {
        base.Action(writer);
    }

    public override Packet Read(BinaryReader reader)
    {
        reader.ReadInt32();
        reader.ReadInt16();
        reader.ReadByte();
        reader.ReadInt16();
        reader.ReadInt32();
        reader.ReadInt32();
        reader.ReadInt32();
        reader.ReadByte();
        reader.ReadByte();
        reader.ReadByte();
        base.Read(reader);
        return this;
    }
}
