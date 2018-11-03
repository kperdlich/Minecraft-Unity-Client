using UnityEngine;
using System.Collections;
using System.IO;

public class PacketChangeGameState : Packet
{
    public static readonly byte ID = 0x46;
    private byte reason = 0, gameMode = 0;

    public PacketChangeGameState() : base(ID)
    {
    }

    public override Packet Read(BinaryReader reader)
    {
        reason = reader.ReadByte();
        gameMode = reader.ReadByte();
        return base.Read(reader);
    }
}
