using UnityEngine;
using System.Collections;
using System.IO;

public class PacketPlayerPositionAndLook : Packet
{
    public static readonly byte ID = 0x0D;
    private double x = .0, y = .0, stance = .0, z = .0;
    private float yaw = .0f, pitch = .0f;
    private bool onGround = false;

    public PacketPlayerPositionAndLook() : base(ID)
    {
    }

    public override void Action(BinaryWriter writer)
    {
        MinecraftTcpConnection.playerSpawned = true;
        Send(writer);
    }

    public override Packet Read(BinaryReader reader)
    {
        x = reader.ReadDouble();
        stance = reader.ReadDouble();
        y = reader.ReadDouble();
        z = reader.ReadDouble();
        yaw = reader.ReadSingle();
        pitch = reader.ReadSingle();
        onGround = reader.ReadBoolean();
        return base.Read(reader);
    }

    public override Packet Send(BinaryWriter writer)
    {
        base.Send(writer);
        writer.Write(x);
        writer.Write(y);
        writer.Write(stance);        
        writer.Write(z);
        writer.Write(yaw);
        writer.Write(pitch);
        writer.Write(onGround);
        return this;
    }
}
