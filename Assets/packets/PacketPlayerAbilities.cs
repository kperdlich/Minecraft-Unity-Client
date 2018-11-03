using UnityEngine;
using System.Collections;
using System.IO;

public class PacketPlayerAbilities : Packet
{
    public static readonly byte ID = 0xCA;
    private bool isFlying, canFly, invulnerability, instantDestroy;

    public PacketPlayerAbilities() : base(ID)
    {
    }

    public override Packet Read(BinaryReader reader)
    {
        invulnerability = reader.ReadBoolean();
        isFlying = reader.ReadBoolean();
        canFly = reader.ReadBoolean();
        instantDestroy= reader.ReadBoolean();
        return base.Read(reader);
    }
}
