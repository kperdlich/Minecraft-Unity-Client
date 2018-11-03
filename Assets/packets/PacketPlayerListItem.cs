using UnityEngine;
using System.Collections;
using System.IO;

public class PacketPlayerListItem : Packet
{
    public static readonly byte ID = 0xC9;
    private string playerName = null;
    private bool online = false;
    private short ping = 0;

    public PacketPlayerListItem() : base(ID)
    {
    }

    public override Packet Read(BinaryReader reader)
    {
        playerName = reader.ReadString();
        online = reader.ReadBoolean();
        ping = reader.ReadInt16();
        return base.Read(reader);
    }
}
