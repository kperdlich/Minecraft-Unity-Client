using UnityEngine;
using System.Collections;
using System.IO;

public class PacketPlayer : Packet
{
    public static readonly byte ID = 0x0A;

    public PacketPlayer() : base(ID)
    {
    }

    public override Packet Send(BinaryWriter writer)
    {
        base.Send(writer);
        writer.Write(false);
        return this;
    }
}
