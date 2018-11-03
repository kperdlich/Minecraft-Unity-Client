using UnityEngine;
using System.Collections;
using System.IO;

public class PacketUpdateTileEntity : Packet
{
    public static readonly byte ID = 0x84;
    private int x = 0, z = 0;
    private short y = 0;
    private byte action = 0;
    private int custom1 = 0, custom2 = 0, custom3 = 0;

    public PacketUpdateTileEntity() : base(ID)
    {
    }

    public override Packet Read(BinaryReader reader)
    {
        x = reader.ReadInt32();
        y = reader.ReadInt16();
        z = reader.ReadInt32();
        action = reader.ReadByte();
        custom1 = reader.ReadInt32();
        custom2 = reader.ReadInt32();
        custom3 = reader.ReadInt32();
        return base.Read(reader);
    }
}
