using UnityEngine;
using System.Collections;
using System.IO;

public class PacketUpdateHealth : Packet
{
    public static readonly byte ID = 0x08;
    private short health = 0, food = 0;
    private float foodSaturation = .0f;

    public PacketUpdateHealth() : base(ID)
    {
    }

    public override Packet Read(BinaryReader reader)
    {
        health = reader.ReadInt16();
        food = reader.ReadInt16();
        foodSaturation = reader.ReadSingle();
        return base.Read(reader);
    }
}
