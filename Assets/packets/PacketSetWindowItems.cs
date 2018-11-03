using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;

// todo move to base class
public class SlotData
{
    public short BlockID;
    public byte ItemCount;
    public short ItemDamage;
    public byte NBT;

    public SlotData ReadFrom(BinaryReader reader)
    {        
        BlockID = reader.ReadInt16();
        if (BlockID != -1) // todo currently always -1, handle correct!
        {
            ItemCount = reader.ReadByte();
            ItemDamage = reader.ReadInt16();
            NBT = reader.ReadByte(); // todo handle nbt correctly
        }
        return this;
    }
}

public class PacketSetWindowItems : Packet
{
    public static readonly byte ID = 0x68;
    private byte windowID = 0;
    private short count = 0;
    private List<SlotData> slotDataList;

    public PacketSetWindowItems() : base(ID)
    {
    }

    public override Packet Read(BinaryReader reader)
    {
        slotDataList = new List<SlotData>();
        windowID = reader.ReadByte();
        count = reader.ReadInt16();
        
        for (int i = 0; i < count; ++i)
        {            
            slotDataList.Add(new SlotData().ReadFrom(reader));
        }        

        return base.Read(reader);
    }
}
