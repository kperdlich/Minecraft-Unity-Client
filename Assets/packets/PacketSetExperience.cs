using UnityEngine;
using System.Collections;
using System.IO;

public class PacketSetExperience : Packet
{
    public static readonly byte ID = 0x2B;
    private float experienceBar = .0f;
    private short level = 0, totalExperience = 0;

    public PacketSetExperience() : base(ID)
    {
    }

    public override Packet Read(BinaryReader reader)
    {
        experienceBar = reader.ReadSingle();
        level = reader.ReadInt16();
        totalExperience = reader.ReadInt16();
        return base.Read(reader);
    }
}
