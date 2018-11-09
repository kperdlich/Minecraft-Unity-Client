using UnityEngine;
using System.Collections;
using System.IO;

public class PacketEntityEquipment : Packet
{
    public static readonly byte ID = 0x05;

    public int EID;
    public short Slot, ItemID, Damage;

    public PacketEntityEquipment() : base(ID)
    {
    }

    public override void Action(BinaryWriter writer)
    {
        base.Action(writer);
    }

    public override Packet Read(BinaryReader reader)
    {
        base.Read(reader);
        EID = reader.ReadInt32();
        Slot = reader.ReadInt16();
        ItemID = reader.ReadInt16();
        Damage = reader.ReadInt16();
        return this;
    }
}
