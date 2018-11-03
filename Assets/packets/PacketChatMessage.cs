using UnityEngine;
using System.Collections;
using System.IO;

public class PacketChatMessage : Packet
{
    public static readonly byte ID = 0x03;

    private string message = null;

    public PacketChatMessage() : base(ID)
    {
    }

    public override Packet Read(BinaryReader reader)
    {
        message = reader.ReadString();
        return base.Read(reader);
    }

    public override Packet Send(BinaryWriter writer)
    {
        writer.Write(message);
        return base.Send(writer);
    }
}
