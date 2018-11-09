using UnityEngine;
using System.Collections;
using System.IO;

public class PacketSpawnNamedEntity : Packet
{
    public static readonly byte ID = 0x14;

    public string playerName;
    public int eid, x, y, z;
    public byte yaw, pitch;
    public short currentItem;

    public PacketSpawnNamedEntity() : base(ID)
    {
    }

    public override void Action(BinaryWriter writer)
    {
        base.Action(writer);
        // todo
    }

    public override Packet Read(BinaryReader reader)
    {
        eid = reader.ReadInt32();
        playerName = reader.ReadString();
        x = reader.ReadInt32();
        y = reader.ReadInt32();
        z = reader.ReadInt32();
        yaw = reader.ReadByte();
        pitch = reader.ReadByte();
        currentItem = reader.ReadInt16();
        return base.Read(reader); ;
    }
}
