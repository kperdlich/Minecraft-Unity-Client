using UnityEngine;
using System.Collections;
using System.IO;

public class PacketPlayerPosition : Packet {

    public static readonly byte ID = 0x0B;
    public double x = .0, y = .0, stance = .0, z = .0;
    public bool onGround = false;

    public PacketPlayerPosition() : base(ID)
    {
    }

    public override void Action(BinaryWriter writer)
    {
        base.Action(writer);
    }

    public override Packet Send(BinaryWriter writer)
    {
        base.Send(writer);
        writer.Write(x);
        writer.Write(y);
        writer.Write(stance);
        writer.Write(z);
        writer.Write(onGround);
        return this;
    }
}
