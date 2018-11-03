using UnityEngine;
using System.Collections;
using System.IO;

public class PacketKeepAlive : Packet
{
    public static readonly byte ID = 0x00;
    private int keepAliveId = 0;

    public PacketKeepAlive() : base(ID)
    {
    }

    public override void Action(BinaryWriter writer)
    {
        Send(writer);
    }

    public override Packet Read(BinaryReader reader)
    {        
        keepAliveId = reader.ReadInt32();
        return this;
    }

    public override Packet Send(BinaryWriter writer)
    {
        base.Send(writer);
        writer.Write(keepAliveId);
        return this;
    }
}

