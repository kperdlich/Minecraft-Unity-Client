using UnityEngine;
using System.Collections;
using System.IO;

public class PacketSetSlot : Packet
{
    public static readonly byte ID = 0x67;
    private byte windowsID = 0;
    private short slot = 0;
    private SlotData slotData;

    public PacketSetSlot() : base(ID)
    {
    }

    public override Packet Read(BinaryReader reader)
    {
        windowsID = reader.ReadByte();
        slot = reader.ReadInt16();
        slotData = new SlotData().ReadFrom(reader);
        return base.Read(reader);
    }
}
