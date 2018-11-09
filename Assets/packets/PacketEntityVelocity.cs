using UnityEngine;
using System.Collections;
using System.IO;

public class PacketEntityVelocity : Packet {

    public static readonly byte ID = 0x1C;

    public PacketEntityVelocity() : base(ID)
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
        reader.ReadInt16();
        reader.ReadInt16();

        return base.Read(reader);
    }
}
