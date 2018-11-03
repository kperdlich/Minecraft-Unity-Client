using UnityEngine;
using System.Collections;
using System.IO;

public class PacketCollectItem : Packet
{
    public static readonly byte ID = 0x16;
    private int collectedEID = 0, collectorEID = 0;

    public PacketCollectItem() : base(ID)
    {
    }

    public override Packet Read(BinaryReader reader)
    {
        collectedEID = reader.ReadInt32();
        collectorEID = reader.ReadInt32();
        return base.Read(reader);
    }
}
